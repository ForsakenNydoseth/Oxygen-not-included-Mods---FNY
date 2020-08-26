using System;
using TUNING;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class FertilizerMakerConfig : IBuildingConfig
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override BuildingDef CreateBuildingDef()
	{
		string text = "HydroCarbon Condenser";
		int num = 2;
		int num2 = 2;
		string text2 = "hydrocarbon_kanim";
		int num3 = 30;
		float num4 = 30f;
		float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
		string[] all_METALS = MATERIALS.ALL_METALS;
		float num5 = 800f;
		BuildLocationRule buildLocationRule = 1;
		EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER5;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_METALS, num5, buildLocationRule, BUILDINGS.DECOR.PENALTY.TIER2, tier2, 0.2f);
		buildingDef.RequiresPowerInput = true;
		buildingDef.EnergyConsumptionWhenActive = 240f;
		buildingDef.ExhaustKilowattsWhenActive = 1f;
		buildingDef.SelfHeatKilowattsWhenActive = 2f;
		buildingDef.InputConduitType = 1;
		buildingDef.OutputConduitType = 2;
		buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
		buildingDef.AudioCategory = "HollowMetal";
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		return buildingDef;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002134 File Offset: 0x00000334
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
		storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
		EntityTemplateExtensions.AddOrGet<WaterPurifier>(go);
		ManualDeliveryKG manualDeliveryKG = go.AddComponent<ManualDeliveryKG>();
		manualDeliveryKG.SetStorage(storage);
		manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
		manualDeliveryKG.requestedItemTag = GameTags.CarbonDioxide;
		manualDeliveryKG.capacity = 1000.5f;
		manualDeliveryKG.refillMass = 100f;
		ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
		conduitConsumer.conduitType = 1;
		conduitConsumer.capacityTag = ElementLoader.FindElementByHash(-1046145888).tag;
		conduitConsumer.capacityKG = 100f;
		conduitConsumer.wrongElementResult = 1;
		conduitConsumer.forceAlwaysSatisfied = true;
		ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
		conduitDispenser.conduitType = 2;
		conduitDispenser.invertElementFilter = true;
		conduitDispenser.elementFilter = new SimHashes[]
		{
			1960575215
		};
		ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
		{
			new ElementConverter.ConsumedElement(new Tag("Hydrogen"), 0.1833f),
			new ElementConverter.ConsumedElement(GameTags.CarbonDioxide, 0.31667f)
		};
		elementConverter.outputElements = new ElementConverter.OutputElement[]
		{
			new ElementConverter.OutputElement(0.73335f, -486269331, 420.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0)
		};
		Prioritizable.AddRef(go);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000022AA File Offset: 0x000004AA
	public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000022B4 File Offset: 0x000004B4
	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000022BE File Offset: 0x000004BE
	public override void DoPostConfigureComplete(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
		EntityTemplateExtensions.AddOrGet<LogicOperationalController>(go);
		EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go);
	}

	// Token: 0x04000001 RID: 1
	public const string ID = "CarbonCondenser";
}
