using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace PropaneExtractor
{
	// Token: 0x02000005 RID: 5
	internal class NaturalGasExtractorPatch
	{
		// Token: 0x0200000F RID: 15
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000026 RID: 38 RVA: 0x00002EF8 File Offset: 0x000010F8
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					NaturalGasExtractorPatch.ImplementationPatch.NAME.key.String,
					NaturalGasExtractorPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					NaturalGasExtractorPatch.ImplementationPatch.DESC.key.String,
					NaturalGasExtractorPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					NaturalGasExtractorPatch.ImplementationPatch.EFFECT.key.String,
					NaturalGasExtractorPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Refining", "Tar Distilator");
			}

			// Token: 0x06000027 RID: 39 RVA: 0x00002F9C File Offset: 0x0000119C
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(TarDistilatorConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000013 RID: 19
			public static LocString NAME = new LocString("Tar Distilator", "STRINGS.BUILDINGS.PREFABS." + "Tar Distilator".ToUpper() + ".NAME");

			// Token: 0x04000014 RID: 20
			public static LocString DESC = new LocString("Tar Distilator , Makes tar...Litteraly its only purpose.", "STRINGS.BUILDINGS.PREFABS." + "Tar Distilator".ToUpper() + ".DESC");

			// Token: 0x04000015 RID: 21
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Are you lookin' to transform your r.... \nOh Right this isnt an ad for stardust LED's \nWell , I guess you came here for the tar didnt you , you just couldnt produce enough from that electric grill could you? \nUse the power of Coal , Algae and a dash of water to make this black sludge that u can burn for power or use as a fuel source in other things coming soon.."
			}), "STRINGS.BUILDINGS.PREFABS." + "Tar Distilator".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000010 RID: 16
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x0600002A RID: 42 RVA: 0x00003060 File Offset: 0x00001260
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["ImprovedCombustion"])
				{
					"Tar Distilator"
				};
				Techs.TECH_GROUPING["ImprovedCombustion"] = list.ToArray();
			}
		}
	}
}
