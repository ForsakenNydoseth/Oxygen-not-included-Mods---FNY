using System;
using Harmony;

namespace Rotate_Tubinez
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(SteamTurbineConfig2), "CreateBuildingDef")]
	public class RotateEmGood
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002506 File Offset: 0x00000706
		public static void Postfix(BuildingDef __result)
		{
			__result.PermittedRotations = 2;
			__result.BuildLocationRule = 13;
			__result.Floodable = false;
		}
	}
}
