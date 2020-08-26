using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace PropaneExtractor
{
	// Token: 0x02000003 RID: 3
	internal class GeneratorPatch
	{
		// Token: 0x02000004 RID: 4
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000008 RID: 8 RVA: 0x00002314 File Offset: 0x00000514
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					GeneratorPatch.ImplementationPatch.NAME.key.String,
					GeneratorPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					GeneratorPatch.ImplementationPatch.DESC.key.String,
					GeneratorPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					GeneratorPatch.ImplementationPatch.EFFECT.key.String,
					GeneratorPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Power", "Crude Burner");
			}

			// Token: 0x06000009 RID: 9 RVA: 0x000023B8 File Offset: 0x000005B8
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(DeuteriumGeneratorConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000002 RID: 2
			public static LocString NAME = new LocString("Crude Burner", "STRINGS.BUILDINGS.PREFABS." + "Crude Burner".ToUpper() + ".NAME");

			// Token: 0x04000003 RID: 3
			public static LocString DESC = new LocString("Crude Oil is produced by Oil Wells or found in oil biomes throughout the world.", "STRINGS.BUILDINGS.PREFABS." + "Crude Burner".ToUpper() + ".DESC");

			// Token: 0x04000004 RID: 4
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Burn this black sticky chemical to produce electricty and waste ",
				UI.FormatAsLink("CO2", "CARBONDIOXIDE"),
				" and ",
				UI.FormatAsLink("Polluted water.", "DIRTYWATER")
			}), "STRINGS.BUILDINGS.PREFABS." + "Crude Burner".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000005 RID: 5
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x0600000C RID: 12 RVA: 0x000024B0 File Offset: 0x000006B0
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Combustion"])
				{
					"Crude Burner"
				};
				Techs.TECH_GROUPING["Combustion"] = list.ToArray();
			}
		}
	}
}
