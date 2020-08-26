using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Database;
using Harmony;
using STRINGS;
using UnityEngine;

namespace PropaneExtractor
{
	// Token: 0x02000005 RID: 5
	internal class NaturalGasExtractorPatch
	{
		// Token: 0x02000006 RID: 6
		[HarmonyPatch(typeof(BuildingComplete), "OnSpawn")]
		public class ColorPatch
		{
			// Token: 0x0600000C RID: 12 RVA: 0x0000237C File Offset: 0x0000057C
			public static void Postfix(BuildingComplete __instance)
			{
				KAnimControllerBase component = __instance.GetComponent<KAnimControllerBase>();
				bool flag = component != null;
				bool flag2 = flag;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					bool flag5 = __instance.name == "HeliumExtractorComplete";
					bool flag6 = flag5;
					bool flag7 = flag6;
					bool flag8 = flag7;
					if (flag8)
					{
						float num = 255f;
						float num2 = 55f;
						float num3 = 155f;
						component.TintColour = new Color(num / 64f, num2 / 224f, num3 / 208f);
					}
				}
			}
		}

		// Token: 0x02000007 RID: 7
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x0600000E RID: 14 RVA: 0x00002408 File Offset: 0x00000608
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
				ModUtil.AddBuildingToPlanScreen("Refining", "Propane Extractor");
			}

			// Token: 0x0600000F RID: 15 RVA: 0x000024AC File Offset: 0x000006AC
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(NaturalGasExtractorConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000005 RID: 5
			public static LocString NAME = new LocString("Propane Extractor", "STRINGS.BUILDINGS.PREFABS." + "Propane Extractor".ToUpper() + ".NAME");

			// Token: 0x04000006 RID: 6
			public static LocString DESC = new LocString("Propane can be produced from the extration of Crude Oil.", "STRINGS.BUILDINGS.PREFABS." + "Propane Extractor".ToUpper() + ".DESC");

			// Token: 0x04000007 RID: 7
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Transforms ",
				UI.FormatAsLink("Crude Oil", "CRUDEOIL"),
				" into ",
				UI.FormatAsLink("Propane", "PROPANE"),
				" , ",
				UI.FormatAsLink("Sulfur", "SULFUR"),
				" and waste ",
				UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE")
			}), "STRINGS.BUILDINGS.PREFABS." + "Propane Extractor".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000008 RID: 8
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000012 RID: 18 RVA: 0x000025D0 File Offset: 0x000007D0
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Catalytics"])
				{
					"Propane Extractor"
				};
				Techs.TECH_GROUPING["Catalytics"] = list.ToArray();
			}
		}

		// Token: 0x02000009 RID: 9
		[HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
		public class PropaneCombustibleAdder
		{
			// Token: 0x06000014 RID: 20 RVA: 0x00002618 File Offset: 0x00000818
			public static void Postfix(Element elem)
			{
				bool flag = elem.id == -1858722091;
				bool flag2 = flag;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					IEnumerable source = CollectionExtensions.Add<Tag>(elem.oreTags, GameTags.CombustibleGas);
					elem.oreTags = source.Cast<Tag>().ToArray<Tag>();
				}
			}
		}

		// Token: 0x0200000A RID: 10
		[HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
		public class HeliumEnablePatch
		{
			// Token: 0x06000016 RID: 22 RVA: 0x00002664 File Offset: 0x00000864
			public static void Postfix(Element elem)
			{
				bool flag = elem.id == -1554872654 || elem.id == -1934139602;
				bool flag2 = flag;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					elem.disabled = false;
				}
			}
		}

		// Token: 0x0200000B RID: 11
		[HarmonyPatch(typeof(MethaneGeneratorConfig), "DoPostConfigureComplete")]
		public class MethaneGeneratorPropanePatch
		{
			// Token: 0x06000018 RID: 24 RVA: 0x000026A4 File Offset: 0x000008A4
			public static void Postfix(GameObject go)
			{
				ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
				conduitDispenser.elementFilter = CollectionExtensions.Add<SimHashes>(conduitDispenser.elementFilter, -1858722091).ToArray<SimHashes>();
			}
		}

		// Token: 0x0200000C RID: 12
		[HarmonyPatch(typeof(GourmetCookingStationConfig), "ConfigureBuildingTemplate")]
		public class GourmetCookingStationPropanePatch
		{
			// Token: 0x0600001A RID: 26 RVA: 0x000026D4 File Offset: 0x000008D4
			public static void Prefix(GourmetCookingStationConfig __instance)
			{
				Traverse.Create(__instance).Field("FUEL_TAG").SetValue(new Tag(GameTags.CombustibleGas));
			}
		}
	}
}
