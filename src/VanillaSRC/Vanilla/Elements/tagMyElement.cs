using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000011 RID: 17
	public static class tagMyElement
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000026EC File Offset: 0x000008EC
		public static Substance CreateVanillaSubstance(Substance source)
		{
			return ModUtil.CreateSubstance("Vanilla", 2, source.anim, source.material, tagMyElement.Vanilla_WHITE, tagMyElement.Vanilla_WHITE, tagMyElement.Vanilla_WHITE);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002724 File Offset: 0x00000924
		public static Substance CreateMudSubstance(Substance source)
		{
			return ModUtil.CreateSubstance("Mud", 2, source.anim, source.material, tagMyElement.BLOOD_RED, tagMyElement.BLOOD_RED, tagMyElement.BLOOD_RED);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000275C File Offset: 0x0000095C
		private static Texture2D TintTextureVanillaRed(Texture sourceTexture, string name)
		{
			Texture2D texture2D = Util.DuplicateTexture(sourceTexture as Texture2D);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				float num = (float)pixels[i].b;
				pixels[i] = tagMyElement.Vanilla_WHITE;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			texture2D.name = name;
			return texture2D;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000027CC File Offset: 0x000009CC
		private static Texture2D TintTextureMudRed(Texture sourceTexture, string name1)
		{
			Texture2D texture2D = Util.DuplicateTexture(sourceTexture as Texture2D);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				float num = (float)pixels[i].b;
				pixels[i] = tagMyElement.BLOOD_RED;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			texture2D.name = name1;
			return texture2D;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000283C File Offset: 0x00000A3C
		private static Material CreateVanillaExtractMaterial(Material source)
		{
			Material material = new Material(source);
			Texture2D mainTexture = tagMyElement.TintTextureVanillaRed(material.mainTexture, "frozenVanilla");
			material.mainTexture = mainTexture;
			material.name = "matVanillaExtract";
			return material;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000287C File Offset: 0x00000A7C
		private static Material CreateFrozenMudMaterial(Material source)
		{
			Material material = new Material(source);
			Texture2D mainTexture = tagMyElement.TintTextureMudRed(material.mainTexture, "frozenMud");
			material.mainTexture = mainTexture;
			material.name = "matFrozenMud";
			return material;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000028BC File Offset: 0x00000ABC
		public static Substance CreateVanillaExtractSubstance(Material sourceMaterial, KAnimFile sourceAnim)
		{
			return ModUtil.CreateSubstance("VanillaExtract", 3, sourceAnim, tagMyElement.CreateVanillaExtractMaterial(sourceMaterial), tagMyElement.Vanilla_WHITE, tagMyElement.Vanilla_WHITE, tagMyElement.Vanilla_WHITE);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000028F0 File Offset: 0x00000AF0
		public static Substance CreateFrozenMudSubstance(Material sourceMaterial, KAnimFile sourceAnim)
		{
			return ModUtil.CreateSubstance("FrozenMud", 3, sourceAnim, tagMyElement.CreateFrozenMudMaterial(sourceMaterial), tagMyElement.BLOOD_RED, tagMyElement.BLOOD_RED, tagMyElement.BLOOD_RED);
		}

		// Token: 0x04000011 RID: 17
		public static readonly Color32 Vanilla_WHITE = new Color32(243, 229, 171, 206);

		// Token: 0x04000012 RID: 18
		public static readonly Color32 BLOOD_RED = new Color32(77, 7, 7, byte.MaxValue);

		// Token: 0x04000013 RID: 19
		public static readonly SimHashes VanillaSimHash = Hash.SDBMLower("Vanilla");

		// Token: 0x04000014 RID: 20
		public static readonly SimHashes VanillaExtractSimHash = Hash.SDBMLower("VanillaExtract");

		// Token: 0x04000015 RID: 21
		public static readonly SimHashes MudSimHash = Hash.SDBMLower("Mud");

		// Token: 0x04000016 RID: 22
		public static readonly SimHashes FrozenMudSimHash = Hash.SDBMLower("FrozenMud");

		// Token: 0x04000017 RID: 23
		public static readonly Dictionary<SimHashes, string> SimHashNameLookup = new Dictionary<SimHashes, string>
		{
			{
				tagMyElement.VanillaSimHash,
				"Vanilla"
			},
			{
				tagMyElement.VanillaExtractSimHash,
				"VanillaExtract"
			},
			{
				tagMyElement.MudSimHash,
				"Mud"
			},
			{
				tagMyElement.FrozenMudSimHash,
				"FrozenMud"
			}
		};

		// Token: 0x04000018 RID: 24
		public const string CONFIG = "\r\n---\r\nelements:\r\n  - elementId: Vanilla\r\n    maxMass: 300\r\n    liquidCompression: 0.5\r\n    speed: 60\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 2.81\r\n    thermalConductivity: 0.108\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 277.15\r\n    highTemp: 600.15\r\n    lowTempTransitionTarget: VanillaExtract\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.000\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.00\r\n    tags: \r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.Vanilla.NAME\r\n  - elementId: Mud\r\n    maxMass: 1000\r\n    liquidCompression: 1.01\r\n    speed: 100\r\n    minHorizontalFlow: 0.01\r\n    minVerticalFlow: 0.01\r\n    specificHeatCapacity: 3.4\r\n    thermalConductivity: 0.609\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 25\r\n    gasSurfaceAreaMultiplier: 1\r\n    lowTemp: 250.65\r\n    highTemp: 375.9\r\n    lowTempTransitionTarget: FrozenMud\r\n    highTempTransitionTarget: Steam\r\n    highTempTransitionOreId: Iron\r\n    highTempTransitionOreMassConversion: 0.003\r\n    defaultTemperature: 282.15\r\n    defaultMass: 1200\r\n    molarMass: 22\r\n    toxicity: 0\r\n    lightAbsorptionFactor: 0.25\r\n    tags:\r\n    - AnyWater\r\n    isDisabled: false\r\n    state: Liquid\r\n    localizationID: STRINGS.ELEMENTS.BLOOD.NAME\r\n  - elementId: VanillaExtract\r\n    specificHeatCapacity: 2.05\r\n    thermalConductivity: 2.18\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 1\r\n    gasSurfaceAreaMultiplier: 1\r\n    strength: 1\r\n    highTemp: 272.5\r\n    highTempTransitionTarget: Vanilla\r\n    defaultTemperature: 232.15\r\n    defaultMass: 1000\r\n    maxMass: 1100\r\n    # hardnessTier: 3\r\n    hardness: 25\r\n    molarMass: 18.01528\r\n    lightAbsorptionFactor: 0.33333\r\n    materialCategory: Liquifiable\r\n    tags:\r\n    - IceOre\r\n    - BuildableAny\r\n    buildMenuSort: 5\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.FROZENVanilla.NAME\r\n  - elementId: FrozenMud\r\n    specificHeatCapacity: 3.05\r\n    thermalConductivity: 1\r\n    solidSurfaceAreaMultiplier: 1\r\n    liquidSurfaceAreaMultiplier: 1\r\n    gasSurfaceAreaMultiplier: 1\r\n    strength: 1\r\n    highTemp: 272.5\r\n    highTempTransitionTarget: Mud\r\n    defaultTemperature: 230\r\n    defaultMass: 500\r\n    maxMass: 800\r\n    # hardnessTier: 2\r\n    hardness: 10\r\n    molarMass: 35\r\n    lightAbsorptionFactor: 0.8\r\n    materialCategory: Liquifiable\r\n    tags:\r\n    - IceOre\r\n    - Mixture\r\n    - BuildableAny\r\n    buildMenuSort: 5\r\n    isDisabled: false\r\n    state: Solid\r\n    localizationID: STRINGS.ELEMENTS.FROZENBLOOD.NAME\r\n";
	}
}
