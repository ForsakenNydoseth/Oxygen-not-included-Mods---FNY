using System;
using System.Collections;
using Harmony;

namespace Elements.Loader
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(ElementLoader), "Load")]
	internal class ElementLoader_Load
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002398 File Offset: 0x00000598
		private static void Prefix(ref Hashtable substanceList, SubstanceTable substanceTable)
		{
			Substance substance = substanceTable.GetSubstance(1836671383);
			Substance substance2 = substanceTable.GetSubstance(-1412059381);
			Substance substance3 = substanceTable.GetSubstance(873952427);
			substanceList[tagMyElement.LithiumSimHash] = tagMyElement.CreateLithiumSubstance(substance2);
			substanceList[tagMyElement.MoltenLithiumSimHash] = tagMyElement.CreateLithiumSubstance(substance2);
		}
	}
}
