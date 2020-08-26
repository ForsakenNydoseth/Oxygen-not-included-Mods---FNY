using System;
using System.Collections.Generic;
using System.IO;
using Harmony;
using Klei;
using STRINGS;

namespace Elements.Loader
{
	// Token: 0x02000013 RID: 19
	[HarmonyPatch(typeof(ElementLoader), "CollectElementsFromYAML")]
	internal class ElementLoader_CollectElementsFromYAML
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00002A78 File Offset: 0x00000C78
		private static void Postfix(ref List<ElementLoader.ElementEntry> __result)
		{
			string str = "Contains traces of " + UI.FormatAsLink("slime", "SLIMEMOLD") + ".";
			string str2 = "Contains traces of " + UI.FormatAsLink("iron", "IRON") + ".";
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.Vanilla.NAME",
				UI.FormatAsLink("Vanilla", "Vanilla")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.Vanilla.DESC",
				"We ALL know what this really is... " + str
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.FROZENVanilla.NAME",
				UI.FormatAsLink("Frozen Vanilla", "FROZENVanilla")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.FROZENVanilla.DESC",
				"Vanilla that has been frozen, probably not edible. " + str
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.BLOOD.NAME",
				UI.FormatAsLink("Mud", "BLOOD")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.BLOOD.DESC",
				"Bathe in the blood of your enemies! " + str2
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.FROZENBLOOD.NAME",
				UI.FormatAsLink("Frozen Mud", "FROZENBLOOD")
			});
			Strings.Add(new string[]
			{
				"STRINGS.ELEMENTS.FROZENBLOOD.DESC",
				"Mud that has been frozen. " + str2
			});
			FileHandle fileHandle = FileSystem.FindFileHandle(Path.GetFileName("ElementLoader.cs"));
			ElementLoader.ElementEntryCollection elementEntryCollection = YamlIO.Parse<ElementLoader.ElementEntryCollection>("\r\n---\r\nelements:\r\n  - elementId: Vanilla\r\n    maxMass: 1000\r\n    liquidCompression: 1.01\r\n    speed: 100\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 3.4\r\n    thermalConductivity: 0.609\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 250.65\r\n    highTemp: 375.9\r\n    lowTempTransitionTarget: VanillaExtract\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Slime\r\n    highTempTransitionOreMassConversion: 0.003\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.25\r\n    tags:\r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.Vanilla.NAME\r\n  - elementId: Mud\r\n    maxMass: 1000\r\n    liquidCompression: 1.01\r\n    speed: 100\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 3.4\r\n    thermalConductivity: 0.609\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 250.65\r\n    highTemp: 375.9\r\n    lowTempTransitionTarget: FrozenMud\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.003\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.25\r\n    tags:\r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.BLOOD.NAME\r\n  - elementId: VanillaExtract\r\n    specificHeatCapacity: 2.05\r\n    thermalConductivity: 2.18\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 1\r\n    gasSurfaceAreaMultiplier: 1\r\n    strength: 1\r\n    highTemp: 272.5\r\n    highTempTransitionTarget: Vanilla\r\n    defaultTemperature: 232.15\r\n    defaultMass: 1000\r\n    maxMass: 1100\r\n    # hardnessTier: 3\r\n    hardness: 25\r\n    molarMass: 18.01528\r\n    lightAbsorptionFactor: 0.33333\r\n    materialCategory: Liquifiable\r\n    tags:\r\n    - IceOre\r\n    - BuildableAny\r\n    buildMenuSort: 5\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.FROZENVanilla.NAME\r\n  - elementId: FrozenMud\r\n    specificHeatCapacity: 3.05\r\n    thermalConductivity: 1\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 1\r\n    gasSurfaceAreaMultiplier: 1\r\n    strength: 1\r\n    highTemp: 272.5\r\n    highTempTransitionTarget: Mud\r\n    defaultTemperature: 230\r\n    defaultMass: 500\r\n    maxMass: 800\r\n    # hardnessTier: 2\r\n    hardness: 10\r\n    molarMass: 35\r\n    lightAbsorptionFactor: 0.8\r\n    materialCategory: Liquifiable\r\n    tags:\r\n    - IceOre\r\n    - Mixture\r\n    - BuildableAny\r\n    buildMenuSort: 5\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.FROZENBLOOD.NAME\r\n", fileHandle, null, null);
			__result.AddRange(elementEntryCollection.elements);
		}
	}
}
