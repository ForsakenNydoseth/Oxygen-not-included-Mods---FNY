using System;
using System.Collections;
using Harmony;

namespace Elements.Loader
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(ElementLoader), "Load")]
	internal class ElementLoader_Load
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000027D0 File Offset: 0x000009D0
		private static void Prefix(ref Hashtable substanceList, SubstanceTable substanceTable)
		{
			Substance substance = substanceTable.GetSubstance(1836671383);
			Substance substance2 = substanceTable.GetSubstance(-1412059381);
			Substance substance3 = substanceTable.GetSubstance(873952427);
			substanceList[tagMyElement.TritiumSimHash] = tagMyElement.CreateTritiumSubstance(substance2);
			substanceList[tagMyElement.DeuteriumSimHash] = tagMyElement.CreateTritiumSubstance(substance2);
		}
	}
}
