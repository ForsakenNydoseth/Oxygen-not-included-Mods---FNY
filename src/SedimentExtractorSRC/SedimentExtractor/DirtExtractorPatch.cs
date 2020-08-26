using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace SedimentExtractor
{
	// Token: 0x02000005 RID: 5
	internal class DirtExtractorPatch
	{
		// Token: 0x02000006 RID: 6
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x0600000B RID: 11 RVA: 0x00002340 File Offset: 0x00000540
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					DirtExtractorPatch.ImplementationPatch.NAME.key.String,
					DirtExtractorPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					DirtExtractorPatch.ImplementationPatch.DESC.key.String,
					DirtExtractorPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					DirtExtractorPatch.ImplementationPatch.EFFECT.key.String,
					DirtExtractorPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Refining", "Sediment Extractor");
			}

			// Token: 0x04000002 RID: 2
			public static LocString NAME = new LocString("Sediment Extractor", "STRINGS.BUILDINGS.PREFABS." + "Sediment Extractor".ToUpper() + ".NAME");

			// Token: 0x04000003 RID: 3
			public static LocString DESC = new LocString("No.", "STRINGS.BUILDINGS.PREFABS." + "Sediment Extractor".ToUpper() + ".DESC");

			// Token: 0x04000004 RID: 4
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Refines ",
				UI.FormatAsLink("Sedimentary Rock", "SEDIMENTARYROCK"),
				" and ",
				UI.FormatAsLink("Polluted Water", "DIRTYWATER"),
				" into ",
				UI.FormatAsLink("Dirt", "DIRT")
			}), "STRINGS.BUILDINGS.PREFABS." + "Sediment Extractor".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000007 RID: 7
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x0600000E RID: 14 RVA: 0x000024C0 File Offset: 0x000006C0
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"Sediment Extractor"
				};
				Techs.TECH_GROUPING["Agriculture"] = list.ToArray();
			}
		}
	}
}
