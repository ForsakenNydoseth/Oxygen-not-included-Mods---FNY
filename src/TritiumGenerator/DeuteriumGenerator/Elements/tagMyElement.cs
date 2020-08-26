using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000006 RID: 6
	public static class tagMyElement
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000259C File Offset: 0x0000079C
		public static Substance CreateTritiumSubstance(Substance source)
		{
			return ModUtil.CreateSubstance("Tritium", 2, source.anim, source.material, tagMyElement.Tritium_WHITE, tagMyElement.Tritium_WHITE, tagMyElement.Tritium_WHITE);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025D4 File Offset: 0x000007D4
		private static Texture2D TintTextureTritiumRed(Texture sourceTexture, string name)
		{
			Texture2D texture2D = Util.DuplicateTexture(sourceTexture as Texture2D);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				float num = (float)pixels[i].b;
				pixels[i] = tagMyElement.Tritium_WHITE;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			texture2D.name = name;
			return texture2D;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002644 File Offset: 0x00000844
		private static Material CreateTritiumExtractMaterial(Material source)
		{
			Material material = new Material(source);
			Texture2D mainTexture = tagMyElement.TintTextureTritiumRed(material.mainTexture, "frozenTritium");
			material.mainTexture = mainTexture;
			material.name = "matTritium";
			return material;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002684 File Offset: 0x00000884
		public static Substance CreateTritiumExtractSubstance(Material sourceMaterial, KAnimFile sourceAnim)
		{
			return ModUtil.CreateSubstance("Tritium", 3, sourceAnim, tagMyElement.CreateTritiumExtractMaterial(sourceMaterial), tagMyElement.Tritium_WHITE, tagMyElement.Tritium_WHITE, tagMyElement.Tritium_WHITE);
		}

		// Token: 0x04000005 RID: 5
		public static readonly Color32 Deuterium_PURPLE = new Color32(125, 18, byte.MaxValue, 1);

		// Token: 0x04000006 RID: 6
		public static readonly Color32 Tritium_WHITE = new Color32(243, 229, 171, 206);

		// Token: 0x04000007 RID: 7
		public static readonly SimHashes DeuteriumSimHash = Hash.SDBMLower("Deuterium");

		// Token: 0x04000008 RID: 8
		public static readonly SimHashes TritiumSimHash = Hash.SDBMLower("Tritium");

		// Token: 0x04000009 RID: 9
		public static readonly Dictionary<SimHashes, string> SimHashNameLookup = new Dictionary<SimHashes, string>
		{
			{
				tagMyElement.TritiumSimHash,
				"Tritium"
			},
			{
				tagMyElement.DeuteriumSimHash,
				"Deuterium"
			}
		};

		// Token: 0x0400000A RID: 10
		public const string CONFIG = "\r\n---\r\nelements:\r\n  - elementId: Tritium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.TRITIUM.NAME\r\n  - elementId: Deuterium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.DEUTERIUM.NAME\r\n  ";
	}
}
