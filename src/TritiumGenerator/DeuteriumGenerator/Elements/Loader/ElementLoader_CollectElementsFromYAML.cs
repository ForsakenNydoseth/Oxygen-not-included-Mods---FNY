using System;
using System.Collections.Generic;
using System.IO;
using Harmony;
using Klei;
using STRINGS;

namespace Elements.Loader
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(ElementLoader), "CollectElementsFromYAML")]
	internal class ElementLoader_CollectElementsFromYAML
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002834 File Offset: 0x00000A34
		private static void Postfix(ref List<ElementLoader.ElementEntry> __result)
		{
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.TRITIUM.NAME",
				UI.FormatAsLink("Tritium", "TRITIUM")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.TRITIUM.DESC",
				"Hydrogen-3 Izotope found in mere grams on planet 4546b "
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.DEUTERIUM.NAME",
				UI.FormatAsLink("Deuterium", "DEUTERIUM")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.DEUTERIUM.DESC",
				"Hydrogen-3 Izotope found in mere grams on planet 4546b "
			});
			FileHandle fileHandle = FileSystem.FindFileHandle(Path.GetFileName("ElementLoader.cs"));
			ElementLoader.ElementEntryCollection elementEntryCollection = YamlIO.Parse<ElementLoader.ElementEntryCollection>("\r\n---\r\nelements:\r\n  - elementId: Tritium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.TRITIUM.NAME\r\n  - elementId: Deuterium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.DEUTERIUM.NAME\r\n", fileHandle, null, null);
			__result.AddRange(elementEntryCollection.elements);
		}
	}
}
