using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000007 RID: 7
	public static class tagMyElement
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002624 File Offset: 0x00000824
		public static Substance CreateTarSubstance(Substance source)
		{
			return ModUtil.CreateSubstance("Tar", 2, source.anim, source.material, tagMyElement.Tar_WHITE, tagMyElement.Tar_WHITE, tagMyElement.Tar_WHITE);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000265C File Offset: 0x0000085C
		private static Texture2D TintTextureTarRed(Texture sourceTexture, string name)
		{
			Texture2D texture2D = Util.DuplicateTexture(sourceTexture as Texture2D);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				float num = (float)pixels[i].b;
				pixels[i] = tagMyElement.Tar_WHITE;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			texture2D.name = name;
			return texture2D;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000026CC File Offset: 0x000008CC
		private static Material CreateTarExtractMaterial(Material source)
		{
			Material material = new Material(source);
			Texture2D mainTexture = tagMyElement.TintTextureTarRed(material.mainTexture, "frozenTar");
			material.mainTexture = mainTexture;
			material.name = "matTar";
			return material;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000270C File Offset: 0x0000090C
		public static Substance CreateTarExtractSubstance(Material sourceMaterial, KAnimFile sourceAnim)
		{
			return ModUtil.CreateSubstance("Tar", 2, sourceAnim, tagMyElement.CreateTarExtractMaterial(sourceMaterial), tagMyElement.Tar_WHITE, tagMyElement.Tar_WHITE, tagMyElement.Tar_WHITE);
		}

		// Token: 0x04000009 RID: 9
		public static readonly Color32 Tar_WHITE = new Color32(51, 51, 51, 51);

		// Token: 0x0400000A RID: 10
		public static readonly SimHashes TARSimHash = Hash.SDBMLower("Tar");

		// Token: 0x0400000B RID: 11
		public static readonly Dictionary<SimHashes, string> SimHashNameLookup = new Dictionary<SimHashes, string>
		{
			{
				tagMyElement.TARSimHash,
				"Tar"
			}
		};

		// Token: 0x0400000C RID: 12
		public const string CONFIG = "\r\n---\r\nelements:\r\n  - elementId: Tar\r\n    maxMass: 300\r\n    liquidCompression: 2\r\n    speed: 10\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 3.1\r\n    thermalConductivity: 0.56\r\n    solidSurfaceAreaMultiplier: 0.3\r\n    liquidSurfaceAreaMultiplier: 90\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: Ice\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Coal\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 400.15\r\n    defaultMass: 300\r\n    molarMass: 22\r\n    toxicity: 1\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.TAR.NAME\r\n  ";
	}
}
