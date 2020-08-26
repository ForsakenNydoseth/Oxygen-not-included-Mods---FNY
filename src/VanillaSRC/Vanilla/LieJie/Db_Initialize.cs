using System;
using Database;
using Harmony;

namespace LieJie
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(Db), "Initialize")]
	internal class Db_Initialize
	{
		// Token: 0x06000012 RID: 18 RVA: 0x0000251F File Offset: 0x0000071F
		private static void Prefix(Db __instance)
		{
			Techs.TECH_GROUPING["FinerDining"] = Util.Append<string>(Techs.TECH_GROUPING["FinerDining"], "Icebox");
		}
	}
}
