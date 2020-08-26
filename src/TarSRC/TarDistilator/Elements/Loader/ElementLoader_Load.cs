using System;
using System.Collections;
using Harmony;

namespace Elements.Loader
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(ElementLoader), "Load")]
	internal class ElementLoader_Load
	{
		// Token: 0x06000014 RID: 20 RVA: 0x0000280C File Offset: 0x00000A0C
		private static void Prefix(ref Hashtable substanceList, SubstanceTable substanceTable)
		{
			Substance substance = substanceTable.GetSubstance(-1412059381);
			substanceList[tagMyElement.TARSimHash] = tagMyElement.CreateTarSubstance(substance);
		}
	}
}
