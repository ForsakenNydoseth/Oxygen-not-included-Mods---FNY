using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace TritiumManfucaturer1
{
	// Token: 0x02000004 RID: 4
	internal class DeuteriumManfucaturerPatch
	{
		// Token: 0x0200000B RID: 11
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x0600001A RID: 26 RVA: 0x000028F4 File Offset: 0x00000AF4
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					DeuteriumManfucaturerPatch.ImplementationPatch.NAME.key.String,
					DeuteriumManfucaturerPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					DeuteriumManfucaturerPatch.ImplementationPatch.DESC.key.String,
					DeuteriumManfucaturerPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					DeuteriumManfucaturerPatch.ImplementationPatch.EFFECT.key.String,
					DeuteriumManfucaturerPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Power", "Deuterium Manfucaturer");
			}

			// Token: 0x0400000B RID: 11
			public static LocString NAME = new LocString("Deuterium Manfucaturer", "STRINGS.BUILDINGS.PREFABS." + "Deuterium Manfucaturer".ToUpper() + ".NAME");

			// Token: 0x0400000C RID: 12
			public static LocString DESC = new LocString("Deuterium Manfucaturer", "STRINGS.BUILDINGS.PREFABS." + "Deuterium Manfucaturer".ToUpper() + ".DESC");

			// Token: 0x0400000D RID: 13
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Uses ",
				" to generate electricity and hydrogen as a byproduct."
			}), "STRINGS.BUILDINGS.PREFABS." + "Deuterium Manfucaturer".ToUpper() + ".EFFECT");
		}

		// Token: 0x0200000C RID: 12
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x0600001D RID: 29 RVA: 0x00002A34 File Offset: 0x00000C34
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"Deuterium Manfucaturer"
				};
				Techs.TECH_GROUPING["Agriculture"] = list.ToArray();
			}
		}
	}
}
