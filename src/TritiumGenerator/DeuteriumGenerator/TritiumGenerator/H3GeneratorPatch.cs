using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace TritiumGenerator
{
	// Token: 0x0200000A RID: 10
	internal class H3GeneratorPatch
	{
		// Token: 0x0200000D RID: 13
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x0600001F RID: 31 RVA: 0x00002A7C File Offset: 0x00000C7C
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					H3GeneratorPatch.ImplementationPatch.NAME.key.String,
					H3GeneratorPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					H3GeneratorPatch.ImplementationPatch.DESC.key.String,
					H3GeneratorPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					H3GeneratorPatch.ImplementationPatch.EFFECT.key.String,
					H3GeneratorPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Power", "Tritium Generator");
			}

			// Token: 0x0400000E RID: 14
			public static LocString NAME = new LocString("Tritium Generator", "STRINGS.BUILDINGS.PREFABS." + "Tritium Generator".ToUpper() + ".NAME");

			// Token: 0x0400000F RID: 15
			public static LocString DESC = new LocString("Tritium Generator", "STRINGS.BUILDINGS.PREFABS." + "Tritium Generator".ToUpper() + ".DESC");

			// Token: 0x04000010 RID: 16
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Uses ",
				" to generate electricity and hydrogen as a byproduct."
			}), "STRINGS.BUILDINGS.PREFABS." + "Tritium Generator".ToUpper() + ".EFFECT");
		}

		// Token: 0x0200000E RID: 14
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000022 RID: 34 RVA: 0x00002BBC File Offset: 0x00000DBC
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"Tritium Generator"
				};
				Techs.TECH_GROUPING["Agriculture"] = list.ToArray();
			}
		}
	}
}
