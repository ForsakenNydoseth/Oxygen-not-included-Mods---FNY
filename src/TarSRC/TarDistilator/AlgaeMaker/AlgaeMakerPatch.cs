using System;
using System.Collections.Generic;
using AlgaeGrower;
using Database;
using Harmony;

namespace AlgaeMaker
{
	// Token: 0x0200000B RID: 11
	internal class AlgaeMakerPatch
	{
		// Token: 0x02000012 RID: 18
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x0600002C RID: 44 RVA: 0x000030A8 File Offset: 0x000012A8
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					AlgaeMakerPatch.ImplementationPatch.NAME.key.String,
					AlgaeMakerPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					AlgaeMakerPatch.ImplementationPatch.DESC.key.String,
					AlgaeMakerPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					AlgaeMakerPatch.ImplementationPatch.EFFECT.key.String,
					AlgaeMakerPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Refining", "Algae Grower");
			}

			// Token: 0x0600002D RID: 45 RVA: 0x0000314C File Offset: 0x0000134C
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(AlgaeGrowerConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000016 RID: 22
			public static LocString NAME = new LocString("Algae Grower", "STRINGS.BUILDINGS.PREFABS." + "Algae Grower".ToUpper() + ".NAME");

			// Token: 0x04000017 RID: 23
			public static LocString DESC = new LocString("Algae BABY!", "STRINGS.BUILDINGS.PREFABS." + "Algae Grower".ToUpper() + ".DESC");

			// Token: 0x04000018 RID: 24
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Grows algae from polluted water , cuz yknow its logical. "
			}), "STRINGS.BUILDINGS.PREFABS." + "Algae Grower".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000013 RID: 19
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000030 RID: 48 RVA: 0x00003210 File Offset: 0x00001410
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"Algae Grower"
				};
				Techs.TECH_GROUPING["Agriculture"] = list.ToArray();
			}
		}
	}
}
