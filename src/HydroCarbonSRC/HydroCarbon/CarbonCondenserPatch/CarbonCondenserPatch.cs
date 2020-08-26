using System;
using System.Collections.Generic;
using Database;
using Harmony;
using STRINGS;

namespace CarbonCondenserPatch
{
	// Token: 0x02000004 RID: 4
	internal class CarbonCondenserPatch
	{
		// Token: 0x02000005 RID: 5
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000009 RID: 9 RVA: 0x000022F4 File Offset: 0x000004F4
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					CarbonCondenserPatch.ImplementationPatch.NAME.key.String,
					CarbonCondenserPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					CarbonCondenserPatch.ImplementationPatch.DESC.key.String,
					CarbonCondenserPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					CarbonCondenserPatch.ImplementationPatch.EFFECT.key.String,
					CarbonCondenserPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Refining", "HydroCarbon Condenser");
			}

			// Token: 0x04000002 RID: 2
			public static LocString NAME = new LocString("HydroCarbon Condenser", "STRINGS.BUILDINGS.PREFABS." + "HydroCarbon Condenser".ToUpper() + ".NAME");

			// Token: 0x04000003 RID: 3
			public static LocString DESC = new LocString("Hydrocarbons are molecules consisting of both hydrogen and carbon, They are most famous for being the primary constituent of fossil fuels, namely natural gas, petroleum, and coal. ", "STRINGS.BUILDINGS.PREFABS." + "HydroCarbon Condenser".ToUpper() + ".DESC");

			// Token: 0x04000004 RID: 4
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Condenses ",
				UI.FormatAsLink("Hydrogen", "HYDROGEN"),
				" and ",
				UI.FormatAsLink("Carbon Dioxide", "CARBONDIOXIDE"),
				" into a hydrocarbon ",
				UI.FormatAsLink("Petroleum", "PETROLEUM")
			}), "STRINGS.BUILDINGS.PREFABS." + "HydroCarbon Condenser".ToUpper() + ".EFFECT");
		}

		// Token: 0x02000006 RID: 6
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x0600000C RID: 12 RVA: 0x00002474 File Offset: 0x00000674
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Agriculture"])
				{
					"HydroCarbon Condenser"
				};
				Techs.TECH_GROUPING["Combustion"] = list.ToArray();
			}
		}
	}
}
