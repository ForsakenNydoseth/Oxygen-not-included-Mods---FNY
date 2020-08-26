using System;
using STRINGS;
using UnityEngine;

namespace Foods
{
	// Token: 0x0200000C RID: 12
	public class CandyConfig : IEntityConfig
	{
		// Token: 0x06000019 RID: 25 RVA: 0x0000258C File Offset: 0x0000078C
		public GameObject CreatePrefab()
		{
			GameObject gameObject = EntityTemplates.CreateLooseEntity(CandyConfig.Id, UI.FormatAsLink(CandyConfig.Name, CandyConfig.Id), CandyConfig.Description, 1f, false, Assets.GetAnim("candy_kanim"), "object", 26, 1, 0.8f, 0.4f, true, 0, 976099455, null);
			EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(CandyConfig.Id, 2000000f, 5, 255.15f, 277.15f, 3200f, true);
			CandyConfig.Description = "You Like em' You make em'";
			return EntityTemplates.ExtendEntityToFood(gameObject, foodInfo);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000261E File Offset: 0x0000081E
		public void OnPrefabInit(GameObject inst)
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000261E File Offset: 0x0000081E
		public void OnSpawn(GameObject inst)
		{
		}

		// Token: 0x04000008 RID: 8
		public static string Id = "Candy";

		// Token: 0x04000009 RID: 9
		public static string Name = "Candy";

		// Token: 0x0400000A RID: 10
		public static string Description = "You like em' , you make em'";

		// Token: 0x0400000B RID: 11
		public ComplexRecipe Recipe;
	}
}
