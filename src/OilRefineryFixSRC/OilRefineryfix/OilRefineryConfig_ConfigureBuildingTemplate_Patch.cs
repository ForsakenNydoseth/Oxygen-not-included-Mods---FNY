using System;
using Harmony;
using UnityEngine;

namespace OilRefineryOverfix
{
	// Token: 0x02000002 RID: 2
	[HarmonyPatch(typeof(OilRefineryConfig))]
	[HarmonyPatch("ConfigureBuildingTemplate")]
	public class OilRefineryConfig_ConfigureBuildingTemplate_Patch
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Postfix(ref GameObject go)
		{
			OilRefinery oilRefinery = EntityTemplateExtensions.AddOrGet<OilRefinery>(go);
			oilRefinery.overpressureMass = float.PositiveInfinity;
		}
	}
}
