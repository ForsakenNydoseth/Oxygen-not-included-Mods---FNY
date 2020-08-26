using System;
using STRINGS;
using UnityEngine;

namespace Foods
{
	// Token: 0x0200000F RID: 15
	public class MudPuddingConfig : IEntityConfig
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00002644 File Offset: 0x00000844
		public GameObject CreatePrefab()
		{
			GameObject gameObject = EntityTemplates.CreateLooseEntity(MudPuddingConfig.Id, UI.FormatAsLink(MudPuddingConfig.Name, MudPuddingConfig.Id), MudPuddingConfig.Description, 1f, false, Assets.GetAnim("icecream_kanim"), "object", 26, 1, 0.8f, 0.4f, true, 0, 976099455, null);
			EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(MudPuddingConfig.Id, 1600000f, 5, 255.15f, 277.15f, 3200f, true);
			return EntityTemplates.ExtendEntityToFood(gameObject, foodInfo);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000261E File Offset: 0x0000081E
		public void OnPrefabInit(GameObject inst)
		{
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000261E File Offset: 0x0000081E
		public void OnSpawn(GameObject inst)
		{
		}

		// Token: 0x0400000D RID: 13
		public static string Id = "IceCream";

		// Token: 0x0400000E RID: 14
		public static string Name = "Ice Cream";

		// Token: 0x0400000F RID: 15
		public static string Description = "Sound pretty appetisin' huh?";

		// Token: 0x04000010 RID: 16
		public ComplexRecipe Recipe;
	}
}
