using System;
using System.Collections.Generic;
using Harmony;
using STRINGS;
using TUNING;

namespace Foods
{
	// Token: 0x02000010 RID: 16
	public static class NutrienBar
	{
		// Token: 0x0200001A RID: 26
		[HarmonyPatch(typeof(CookingStationConfig), "DoPostConfigureComplete")]
		public static class AddNutrientBarRecipe
		{
			// Token: 0x0600003A RID: 58 RVA: 0x00003124 File Offset: 0x00001324
			public static void Postfix()
			{
				ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("VANILLA", 10f),
					new ComplexRecipe.RecipeElement("POLYPROPYLENE", 15f)
				};
				ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement("FieldRation", 5f)
				};
				ExtraConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", array, array2), array, array2)
				{
					time = FOOD.RECIPES.STANDARD_COOK_TIME * 2f,
					description = string.Concat(new string[]
					{
						"Thin wafers of overcooked ",
						UI.FormatAsLink("Mush Fry", "FRIEDMUSHBAR"),
						", stacked with a crunchy filling of ",
						UI.FormatAsLink("Meal Lice", "BASICPLANTFOOD"),
						"\npermanently immobilized in a dense, sterile aerated polypropylene microfoam emulsion.\n\n\"It was this all along?\"\n-Stinky"
					}),
					nameDisplay = 1,
					fabricators = new List<Tag>
					{
						"CookingStation"
					},
					sortOrder = 21
				};
			}
		}
	}
}
