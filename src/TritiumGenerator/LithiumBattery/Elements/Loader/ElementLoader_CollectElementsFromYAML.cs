using System;
using System.Collections.Generic;
using System.IO;
using Harmony;
using Klei;
using STRINGS;

namespace Elements.Loader
{
	// Token: 0x02000006 RID: 6
	[HarmonyPatch(typeof(ElementLoader), "CollectElementsFromYAML")]
	internal class ElementLoader_CollectElementsFromYAML
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002404 File Offset: 0x00000604
		private static void Postfix(ref List<ElementLoader.ElementEntry> __result)
		{
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.LITHIUM.NAME",
				UI.FormatAsLink("Lithium", "LITHIUM")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.LITHIUM.DESC",
				"Lithium is an element not naturally found on Earth , but rather in trace amounts in certain rocks. "
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.MOLTENLITHIUM.NAME",
				UI.FormatAsLink("MoltenLithium", "MOLTENLITHIUM")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.MOLTENLITHIUM.DESC",
				"The Molten Version of Lithium "
			});
			FileHandle fileHandle = FileSystem.FindFileHandle(Path.GetFileName("ElementLoader.cs"));
			ElementLoader.ElementEntryCollection elementEntryCollection = YamlIO.Parse<ElementLoader.ElementEntryCollection>("\r\n---\r\nelements:\r\n  - elementId: Lithium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: MoltenLithium\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.LITHIUM.NAME\r\n  - elementId: MoltenLithium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 451.7\r\n    highTemp: 1615\r\n    lowTempTransitionTarget: Lithium\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 459.7\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.MOLTENLITHIUM.NAME\r\n", fileHandle, null, null);
			__result.AddRange(elementEntryCollection.elements);
		}
	}
}
