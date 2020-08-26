using System;
using System.Collections.Generic;
using Harmony;
using STRINGS;

namespace Foods
{
	// Token: 0x0200000E RID: 14
	public static class IceCream
	{
		// Token: 0x02000019 RID: 25
		[HarmonyPatch(typeof(CookingStationConfig), "DoPostConfigureComplete")]
		public static class AddIceCream
		{
			// Token: 0x06000039 RID: 57 RVA: 0x00002FF4 File Offset: 0x000011F4
			public static void Postfix()
			{
				ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("GrilledPrickleFruit", 2.5f),
					new ComplexRecipe.RecipeElement("BeanPlantSeed", 0.5f),
					new ComplexRecipe.RecipeElement("VANILLA", 50f)
				};
				ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("IceCream", 5f)
				};
				ExtraConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", array, array2), array, array2)
				{
					time = 30f,
					description = string.Concat(new string[]
					{
						"Hearty chunks of our finest'",
						UI.FormatAsLink("prickle fruits", "PRICKLEFRUIT"),
						"'from the very gardens of this colony with an added flavour of",
						UI.FormatAsLink("Nosh beans", "BeanPlantSeed"),
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
