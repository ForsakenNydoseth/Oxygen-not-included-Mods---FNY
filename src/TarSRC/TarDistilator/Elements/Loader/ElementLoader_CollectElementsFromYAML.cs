using System;
using System.Collections.Generic;
using System.IO;
using Harmony;
using Klei;
using STRINGS;

namespace Elements.Loader
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(ElementLoader), "CollectElementsFromYAML")]
	internal class ElementLoader_CollectElementsFromYAML
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002840 File Offset: 0x00000A40
		private static void Postfix(ref List<ElementLoader.ElementEntry> __result)
		{
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.TAR.NAME",
				UI.FormatAsLink("Tar", "TAR")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.TAR.DESC",
				"Residue of grilling with propane , it leaves all the pipes so dirty. \nYuck! \nCan be refined into some more useful thing lateron. \nKeep it for now."
			});
			FileHandle fileHandle = FileSystem.FindFileHandle(Path.GetFileName("ElementLoader.cs"));
			ElementLoader.ElementEntryCollection elementEntryCollection = YamlIO.Parse<ElementLoader.ElementEntryCollection>("\r\n---\r\nelements:\r\n  - elementId: Tar\r\n    maxMass: 300\r\n    liquidCompression: 2\r\n    speed: 1\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 3.1\r\n    thermalConductivity: 0.56\r\n    solidSurfaceAreaMultiplier: 0.3\r\n    liquidSurfaceAreaMultiplier: 90\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Coal\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 400.15\r\n    defaultMass: 300\r\n    molarMass: 22\r\n    toxicity: 1\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.TAR.NAME\r\n", fileHandle, null, null);
			__result.AddRange(elementEntryCollection.elements);
		}
	}
}
