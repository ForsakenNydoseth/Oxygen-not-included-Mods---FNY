using System;
using Harmony;

namespace PropaneExtractor
{
	// Token: 0x02000002 RID: 2
	[HarmonyPatch(typeof(OilRefinery.WorkableTarget))]
	[HarmonyPatch("OnPrefabInit")]
	internal class AnimationPatch
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Postfix(OilRefinery.WorkableTarget __instance)
		{
			bool flag = __instance.name == "PropaneExtractorComplete";
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
