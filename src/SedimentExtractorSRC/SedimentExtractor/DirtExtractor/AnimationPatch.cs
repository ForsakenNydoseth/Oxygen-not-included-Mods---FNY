using System;
using Harmony;

namespace DirtExtractor
{
	// Token: 0x02000003 RID: 3
	[HarmonyPatch(typeof(OilRefinery.WorkableTarget))]
	[HarmonyPatch("OnPrefabInit")]
	internal class AnimationPatch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000022E4 File Offset: 0x000004E4
		public static void Postfix(OilRefinery.WorkableTarget __instance)
		{
			bool flag = __instance.name == "SedimentExtractorComplete";
			bool flag2 = flag;
			bool flag3 = flag2;
			bool flag4 = flag3;
			if (flag4)
			{
				__instance.overrideAnims = new KAnimFile[]
				{
					Assets.GetAnim("anim_interacts_metalrefinery_kanim")
				};
			}
		}
	}
}
