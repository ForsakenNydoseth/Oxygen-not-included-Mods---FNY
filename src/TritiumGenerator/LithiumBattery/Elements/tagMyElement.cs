using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000003 RID: 3
	public static class tagMyElement
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002164 File Offset: 0x00000364
		public static Substance CreateLithiumSubstance(Substance source)
		{
			return ModUtil.CreateSubstance("Lithium", 3, source.anim, source.material, tagMyElement.Lithium_WHITE, tagMyElement.Lithium_WHITE, tagMyElement.Lithium_WHITE);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000219C File Offset: 0x0000039C
		private static Texture2D TintTextureLithiumRed(Texture sourceTexture, string name)
		{
			Texture2D texture2D = Util.DuplicateTexture(sourceTexture as Texture2D);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				float num = (float)pixels[i].b;
				pixels[i] = tagMyElement.Lithium_WHITE;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			texture2D.name = name;
			return texture2D;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000220C File Offset: 0x0000040C
		private static Material CreateLithiumExtractMaterial(Material source)
		{
			Material material = new Material(source);
			Texture2D mainTexture = tagMyElement.TintTextureLithiumRed(material.mainTexture, "frozenLithium");
			material.mainTexture = mainTexture;
			material.name = "matLithium";
			return material;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000224C File Offset: 0x0000044C
		public static Substance CreateLithiumExtractSubstance(Material sourceMaterial, KAnimFile sourceAnim)
		{
			return ModUtil.CreateSubstance("Lithium", 3, sourceAnim, tagMyElement.CreateLithiumExtractMaterial(sourceMaterial), tagMyElement.Lithium_WHITE, tagMyElement.Lithium_WHITE, tagMyElement.Lithium_WHITE);
		}

		// Token: 0x04000002 RID: 2
		public static readonly Color32 MoltenLithium_PURPLE = new Color32(125, 18, byte.MaxValue, 1);

		// Token: 0x04000003 RID: 3
		public static readonly Color32 Lithium_WHITE = new Color32(243, 229, 171, 206);

		// Token: 0x04000004 RID: 4
		public static readonly SimHashes MoltenLithiumSimHash = Hash.SDBMLower("MoltenLithium");

		// Token: 0x04000005 RID: 5
		public static readonly SimHashes LithiumSimHash = Hash.SDBMLower("Lithium");

		// Token: 0x04000006 RID: 6
		public static readonly Dictionary<SimHashes, string> SimHashNameLookup = new Dictionary<SimHashes, string>
		{
			{
				tagMyElement.LithiumSimHash,
				"Lithium"
			},
			{
				tagMyElement.MoltenLithiumSimHash,
				"MoltenLithium"
			}
		};

		// Token: 0x04000007 RID: 7
		public const string CONFIG = "\r\n---\r\nelements:\r\n  - elementId: Lithium\r\n    maxMass: 300\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 453.7\r\n    lowTempTransitionTarget: Lithium\r\n    highTempTransitionTarget: Molten Lithium\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.LITHIUM.NAME\r\n  - elementId: MoltenLithium\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 451.7\r\n    highTemp: 1615\r\n    lowTempTransitionTarget: Lithium\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 459.7\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.MOLTENLITHIUM.NAME\r\n  ";
	}
}
