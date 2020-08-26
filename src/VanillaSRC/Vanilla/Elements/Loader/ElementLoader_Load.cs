using System;
using System.Collections;
using Harmony;

namespace Elements.Loader
{
	// Token: 0x02000014 RID: 20
	[HarmonyPatch(typeof(ElementLoader), "Load")]
	internal class ElementLoader_Load
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002C10 File Offset: 0x00000E10
		private static void Prefix(ref Hashtable substanceList, SubstanceTable substanceTable)
		{
			Substance substance = substanceTable.GetSubstance(1836671383);
			Substance substance2 = substanceTable.GetSubstance(-1412059381);
			Substance substance3 = substanceTable.GetSubstance(873952427);
			substanceList[tagMyElement.VanillaSimHash] = tagMyElement.CreateVanillaSubstance(substance2);
			substanceList[tagMyElement.VanillaExtractSimHash] = tagMyElement.CreateVanillaExtractSubstance(substance3.material, substance.anim);
			substanceList[tagMyElement.MudSimHash] = tagMyElement.CreateMudSubstance(substance);
			substanceList[tagMyElement.FrozenMudSimHash] = tagMyElement.CreateFrozenMudSubstance(substance3.material, substance.anim);
		}
	}
}
