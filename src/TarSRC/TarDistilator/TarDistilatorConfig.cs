using System;
using Elements;
using TUNING;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class TarDistilatorConfig : IBuildingConfig
{
	// Token: 0x06000007 RID: 7 RVA: 0x000022CC File Offset: 0x000004CC
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Tar Distilator";
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
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_METALS, num5, buildLocationRule, BUILDINGS.DECOR.PENALTY.TIER1, tier2, 0.2f);
		buildingDef.RequiresPowerInput = true;
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.EnergyConsumptionWhenActive = 480f;
		buildingDef.ExhaustKilowattsWhenActive = 2f;
		buildingDef.SelfHeatKilowattsWhenActive = 32f;
		buildingDef.PermittedRotations = 3;
		buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
		buildingDef.AudioCategory = "HollowMetal";
		buildingDef.InputConduitType = 2;
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		buildingDef.OutputConduitType = 1;
		buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
		return buildingDef;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000023C8 File Offset: 0x000005C8
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		EntityTemplateExtensions.AddOrGet<BuildingComplete>(go).isManuallyOperated = false;
		OilRefinery oilRefinery = EntityTemplateExtensions.AddOrGet<OilRefinery>(go);
		oilRefinery.overpressureWarningMass = 1000000f;
		oilRefinery.overpressureMass = 1E+07f;
		Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
		storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
		EntityTemplateExtensions.AddOrGet<WaterPurifier>(go);
		ManualDeliveryKG manualDeliveryKG = go.AddComponent<ManualDeliveryKG>();
		manualDeliveryKG.SetStorage(storage);
		manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
		manualDeliveryKG.requestedItemTag = GameTags.Organics;
		manualDeliveryKG.refillMass = 600f;
		ManualDeliveryKG manualDeliveryKG2 = go.AddComponent<ManualDeliveryKG>();
		manualDeliveryKG2.SetStorage(storage);
		manualDeliveryKG2.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
		manualDeliveryKG2.requestedItemTag = GameTags.Carbon;
		manualDeliveryKG2.capacity = 1000.5f;
		manualDeliveryKG2.refillMass = 500f;
		ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
		conduitConsumer.conduitType = 2;
		conduitConsumer.consumptionRate = 10f;
		conduitConsumer.capacityTag = GameTagExtensions.CreateTag(1836671383);
		conduitConsumer.wrongElementResult = 1;
		conduitConsumer.capacityKG = 100f;
		conduitConsumer.forceAlwaysSatisfied = true;
		ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
		conduitDispenser.conduitType = 1;
		conduitDispenser.invertElementFilter = true;
		conduitDispenser.elementFilter = new SimHashes[]
		{
			1836671383
		};
		EntityTemplateExtensions.AddOrGet<Storage>(go).showInUI = true;
		ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
		{
			new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(947100397), 0.12f),
			new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(-1870043872), 0.14f),
			new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(1836671383), 1f)
		};
		elementConverter.outputElements = new ElementConverter.OutputElement[]
		{
			new ElementConverter.OutputElement(1.16f, tagMyElement.TARSimHash, 333.15f, false, false, 0f, 1f, 1f, byte.MaxValue, 0),
			new ElementConverter.OutputElement(0.1f, -899515856, 438.15f, false, true, 0f, 3f, 1f, byte.MaxValue, 0)
		};
		Prioritizable.AddRef(go);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002615 File Offset: 0x00000815
	public override void DoPostConfigureComplete(GameObject go)
	{
	}

	// Token: 0x04000002 RID: 2
	public const string ID = "TarDistilator";

	// Token: 0x04000003 RID: 3
	public const SimHashes INPUT_ELEMENT = -1412059381;

	// Token: 0x04000004 RID: 4
	private const SimHashes OUTPUT_LIQUID_ELEMENT = -486269331;

	// Token: 0x04000005 RID: 5
	private const SimHashes OUTPUT_GAS_ELEMENT = -841236436;

	// Token: 0x04000006 RID: 6
	public const float CONSUMPTION_RATE = 10f;

	// Token: 0x04000007 RID: 7
	public const float OUTPUT_LIQUID_RATE = 5f;

	// Token: 0x04000008 RID: 8
	public const float OUTPUT_GAS_RATE = 0.09f;
}
