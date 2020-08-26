using System;
using TUNING;
using UnityEngine;

namespace PropaneExtractor
{
	// Token: 0x02000004 RID: 4
	public class NaturalGasExtractorConfig : IBuildingConfig
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020AC File Offset: 0x000002AC
		public override BuildingDef CreateBuildingDef()
		{
			string text = "Propane Extractor";
			int num = 4;
			int num2 = 4;
			string text2 = "oilrefinery_kanim";
			int num3 = 30;
			float num4 = 30f;
			float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
			string[] all_METALS = MATERIALS.ALL_METALS;
			float num5 = 800f;
			BuildLocationRule buildLocationRule = 1;
			EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_METALS, num5, buildLocationRule, BUILDINGS.DECOR.PENALTY.TIER2, tier2, 0.2f);
			buildingDef.RequiresPowerInput = true;
			buildingDef.PowerInputOffset = new CellOffset(1, 0);
			buildingDef.EnergyConsumptionWhenActive = 480f;
			buildingDef.SelfHeatKilowattsWhenActive = 10f;
			buildingDef.AudioCategory = "HollowMetal";
			buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
			buildingDef.InputConduitType = 2;
			buildingDef.OutputConduitType = 1;
			buildingDef.UtilityInputOffset = new CellOffset(1, 0);
			buildingDef.UtilityOutputOffset = new CellOffset(-1, 3);
			buildingDef.ModifiesTemperature = true;
			return buildingDef;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000219C File Offset: 0x0000039C
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
			EntityTemplateExtensions.AddOrGet<BuildingComplete>(go).isManuallyOperated = true;
			Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
			storage.showInUI = true;
			storage.capacityKg = 2f;
			storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
			NaturalGasExtractor naturalGasExtractor = EntityTemplateExtensions.AddOrGet<NaturalGasExtractor>(go);
			naturalGasExtractor.overpressureMass = 10f;
			ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
			conduitConsumer.conduitType = 2;
			conduitConsumer.consumptionRate = NaturalGasExtractorConfig.totalConversion;
			conduitConsumer.capacityTag = GameTagExtensions.CreateTag(-1412059381);
			conduitConsumer.wrongElementResult = 1;
			conduitConsumer.capacityKG = 2f;
			conduitConsumer.forceAlwaysSatisfied = true;
			ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
			conduitDispenser.conduitType = 1;
			conduitDispenser.invertElementFilter = true;
			conduitDispenser.elementFilter = new SimHashes[]
			{
				-1412059381
			};
			EntityTemplateExtensions.AddOrGet<Storage>(go);
			storage.showInUI = true;
			ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
			elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
			{
				new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(-1412059381), NaturalGasExtractorConfig.totalConversion)
			};
			elementConverter.outputElements = new ElementConverter.OutputElement[]
			{
				new ElementConverter.OutputElement(NaturalGasExtractorConfig.sulfureConversionRate, -729385479, 350.15f, false, false, 0f, 0.5f, 1f, byte.MaxValue, 0),
				new ElementConverter.OutputElement(NaturalGasExtractorConfig.propaneConversionRate, -1858722091, 400.15f, false, true, 1f, 1f, 1f, byte.MaxValue, 0)
			};
			Prioritizable.AddRef(go);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002321 File Offset: 0x00000521
		public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000232B File Offset: 0x0000052B
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002335 File Offset: 0x00000535
		public override void DoPostConfigureComplete(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
			EntityTemplateExtensions.AddOrGet<LogicOperationalController>(go);
			EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go);
		}

		// Token: 0x04000001 RID: 1
		public static float totalConversion = 0.4f;

		// Token: 0x04000002 RID: 2
		public static float sulfureConversionRate = 0.05f;

		// Token: 0x04000003 RID: 3
		public static float propaneConversionRate = NaturalGasExtractorConfig.totalConversion - NaturalGasExtractorConfig.sulfureConversionRate;

		// Token: 0x04000004 RID: 4
		public const string ID = "PropaneExtractor";
	}
}
