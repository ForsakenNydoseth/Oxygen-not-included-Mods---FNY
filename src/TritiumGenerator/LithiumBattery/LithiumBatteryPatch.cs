using System;
using System.Collections.Generic;
using Database;
using Harmony;

namespace LithiumBatteryPatch
{
	// Token: 0x02000008 RID: 8
	internal class LithiumBatteryPatch
	{
		// Token: 0x02000009 RID: 9
		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch("LoadGeneratedBuildings")]
		public class ImplementationPatch
		{
			// Token: 0x06000010 RID: 16 RVA: 0x000024CC File Offset: 0x000006CC
			private static void Prefix()
			{
				Strings.Add(new string[]
				{
					LithiumBatteryPatch.ImplementationPatch.NAME.key.String,
					LithiumBatteryPatch.ImplementationPatch.NAME.text
				});
				Strings.Add(new string[]
				{
					LithiumBatteryPatch.ImplementationPatch.DESC.key.String,
					LithiumBatteryPatch.ImplementationPatch.DESC.text
				});
				Strings.Add(new string[]
				{
					LithiumBatteryPatch.ImplementationPatch.EFFECT.key.String,
					LithiumBatteryPatch.ImplementationPatch.EFFECT.text
				});
				ModUtil.AddBuildingToPlanScreen("Power", "Lithium Battery");
			}

			// Token: 0x06000011 RID: 17 RVA: 0x00002570 File Offset: 0x00000770
			private static void Postfix()
			{
				object obj = Activator.CreateInstance(typeof(LithiumBatteryConfig));
				BuildingConfigManager.Instance.RegisterBuilding(obj as IBuildingConfig);
			}

			// Token: 0x04000008 RID: 8
			public static LocString NAME = new LocString("Lithium Battery", "STRINGS.BUILDINGS.PREFABS." + "Lithium Battery".ToUpper() + ".NAME");

			// Token: 0x04000009 RID: 9
			public static LocString DESC = new LocString("Lithium Ion Battery uses Lithium , Graphite Copper and Aluminum to convert Chemical Energy to Electrical energy.", "STRINGS.BUILDINGS.PREFABS." + "Lithium Battery".ToUpper() + ".DESC");

			// Token: 0x0400000A RID: 10
			public static LocString EFFECT = new LocString(string.Concat(new string[]
			{
				"Lithium Ion Battery uses Lithium , Graphite Copper and Aluminum to convert Chemical Energy to Electrical energy"
			}), "STRINGS.BUILDINGS.PREFABS." + "Lithium Battery".ToUpper() + ".EFFECT");
		}

		// Token: 0x0200000A RID: 10
		[HarmonyPatch(typeof(Db), "Initialize")]
		public class DatabaseAddingPatch
		{
			// Token: 0x06000014 RID: 20 RVA: 0x00002634 File Offset: 0x00000834
			public static void Prefix()
			{
				List<string> list = new List<string>(Techs.TECH_GROUPING["Catalytics"])
				{
					"Lithium Battery"
				};
				Techs.TECH_GROUPING["Catalytics"] = list.ToArray();
			}
		}
	}
}
