using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace PropaneExtractor
{
	// Token: 0x02000004 RID: 4
	internal class GeneratorPatch
	{
		// Token: 0x0200000D RID: 13
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000020 RID: 32 RVA: 0x00002CF8 File Offset: 0x00000EF8
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
				ModUtil.AddBuildingToPlanScreen("Power", "Tar Generator");
			}

			// Token: 0x06000021 RID: 33 RVA: 0x00002D9C File Offset: 0x00000F9C
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(TarDistilatorConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000010 RID: 16
			public static LocString NAME = new LocString("Tar Generator", "STRINGS.BUILDINGS.PREFABS." + "Tar Generator".ToUpper() + ".NAME");

			// Token: 0x04000011 RID: 17
			public static LocString DESC = new LocString("Propane can be produced from the extration of Crude Oil.", "STRINGS.BUILDINGS.PREFABS." + "Tar Generator".ToUpper() + ".DESC");

			// Token: 0x04000012 RID: 18
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"If you are low on power and are desparate for more while still having no access to elements such as: ",
				UI.FormatAsLink("Crude Oil", "CRUDEOIL"),
				" , ",
				UI.FormatAsLink("Propane", "PROPANE"),
				" \nor\n",
				UI.FormatAsLink("Natural Gas", "METHANE"),
				" \nLook no further because this...is your solution . \nUse the good ol'e Tar to produce a fuck ton of pollution but get that little bit of power that u need to stay afloat."
			}), "STRINGS.BUILDINGS.PREFABS." + "Tar Generator".ToUpper() + ".EFFECT");
		}

		// Token: 0x0200000E RID: 14
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000024 RID: 36 RVA: 0x00002EB0 File Offset: 0x000010B0
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Combustion"])
				{
					"Tar Generator"
				};
				Techs.TECH_GROUPING["Combustion"] = list.ToArray();
			}
		}
	}
}
