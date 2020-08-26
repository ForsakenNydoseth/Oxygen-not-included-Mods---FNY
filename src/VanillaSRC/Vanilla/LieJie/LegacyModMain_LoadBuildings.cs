using System;
using Harmony;

namespace LieJie
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(LegacyModMain), "LoadBuildings")]
	internal class LegacyModMain_LoadBuildings
	{
		// Token: 0x06000014 RID: 20 RVA: 0x0000254B File Offset: 0x0000074B
		private static void Prefix()
		{
			LocString.CreateLocStringKeys(typeof(PREFABS), "STRINGS.BUILDINGS.");
			ModUtil.AddBuildingToPlanScreen("Food", "Icebox");
		}
	}
}
