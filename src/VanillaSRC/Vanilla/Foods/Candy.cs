using System;
using System.Collections.Generic;
using Harmony;
using STRINGS;

namespace Foods
{
	// Token: 0x0200000B RID: 11
	public static class Candy
	{
		// Token: 0x02000018 RID: 24
		[HarmonyPatch(typeof(CookingStationConfig), "DoPostConfigureComplete")]
		public static class AddCandy
		{
			// Token: 0x06000038 RID: 56 RVA: 0x00002EF4 File Offset: 0x000010F4
			public static void Postfix()
			{
				ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("SolidCarbonDioxide", 15f),
					new ComplexRecipe.RecipeElement("VANILLA", 50f)
				};
				ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("Candy", 5f)
				};
				ExtraConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", array, array2), array, array2)
				{
					time = 60f,
					description = string.Concat(new string[]
					{
						"Some ",
						UI.FormatAsLink("Solid Carbon Dioxide", "SOLIDCARBONDIOXIDE"),
						" and ",
						UI.FormatAsLink("Vanilla", "VANILLA"),
						"\n To hasten the productivity of our dupes!  \n\n\"FOR THE GOOD OF THE PEOPLE\"\n-Liam"
					}),
					nameDisplay = 1,
					fabricators = new List<Tag>
					{
						"CookingStation"
					},
					sortOrder = 120
				};
			}
		}
	}
}
