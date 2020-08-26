using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace VanillaMakerPatch
{
	// Token: 0x02000003 RID: 3
	internal class VanillaMakerPatch
	{
		// Token: 0x02000015 RID: 21
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000031 RID: 49 RVA: 0x00002CB8 File Offset: 0x00000EB8
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					VanillaMakerPatch.ImplementationPatch.NAME.key.String,
					VanillaMakerPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					VanillaMakerPatch.ImplementationPatch.DESC.key.String,
					VanillaMakerPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					VanillaMakerPatch.ImplementationPatch.EFFECT.key.String,
					VanillaMakerPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Refining", "Vanilla Maker");
			}

			// Token: 0x04000019 RID: 25
			public static LocString NAME = new LocString("Vanilla Maker", "STRINGS.BUILDINGS.PREFABS." + "Vanilla Maker".ToUpper() + ".NAME");

			// Token: 0x0400001A RID: 26
			public static LocString DESC = new LocString("Vanilla (C8H8O3) is produced from a chemically very simmilar compund Ethanol (C2H5OH) ", "STRINGS.BUILDINGS.PREFABS." + "Vanilla Maker".ToUpper() + ".DESC");

			// Token: 0x0400001B RID: 27
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Makes Delicious ",
				UI.FormatAsLink("Vanilla", "VANILLA"),
				" from a chemically very simillar compund",
				UI.FormatAsLink("Ethanol", "ETHANOL"),
				" for you to enjoy!"
			}), "STRINGS.BUILDINGS.PREFABS." + "Vanilla Maker".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000016 RID: 22
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000034 RID: 52 RVA: 0x00002E24 File Offset: 0x00001024
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"Vanilla Maker"
				};
				Techs.TECH_GROUPING["Agriculture"] = list.ToArray();
			}
		}
	}
}
