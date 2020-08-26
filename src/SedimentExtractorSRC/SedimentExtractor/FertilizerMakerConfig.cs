using System;
using TUNING;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class FertilizerMakerConfig : IBuildingConfig
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Sediment Extractor";
		int num = 4;
		int num2 = 3;
		string text2 = "fertilizer_maker_kanim";
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
		buildingDef.InputConduitType = 2;
		buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
		buildingDef.AudioCategory = "HollowMetal";
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		return buildingDef;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000212C File Offset: 0x0000032C
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
		storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
		EntityTemplateExtensions.AddOrGet<WaterPurifier>(go);
		ManualDeliveryKG manualDeliveryKG = go.AddComponent<ManualDeliveryKG>();
		manualDeliveryKG.SetStorage(storage);
		manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
		manualDeliveryKG.requestedItemTag = GameTags.BuildableRaw;
		manualDeliveryKG.capacity = 1000.5f;
		manualDeliveryKG.refillMass = 100f;
		ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
		conduitConsumer.conduitType = 2;
		conduitConsumer.capacityTag = ElementLoader.FindElementByHash(1832607973).tag;
		conduitConsumer.capacityKG = 100f;
		conduitConsumer.wrongElementResult = 1;
		conduitConsumer.forceAlwaysSatisfied = false;
		ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
		{
			new ElementConverter.ConsumedElement(new Tag("DirtyWater"), 2f),
			new ElementConverter.ConsumedElement(GameTags.BuildableRaw, 4f)
		};
		elementConverter.outputElements = new ElementConverter.OutputElement[]
		{
			new ElementConverter.OutputElement(6f, 1624244999, 323.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0)
		};
		ElementDropper elementDropper = go.AddComponent<ElementDropper>();
		elementDropper.emitMass = 6f;
		elementDropper.emitTag = new Tag("Dirt");
		elementDropper.emitOffset = new Vector3(0f, 1f, 0f);
		Prioritizable.AddRef(go);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000022B6 File Offset: 0x000004B6
	public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000022C0 File Offset: 0x000004C0
	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000022CA File Offset: 0x000004CA
	public override void DoPostConfigureComplete(GameObject go)
	{
		EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go).showWorkingStatus = true;
	}

	// Token: 0x04000001 RID: 1
	public const string ID = "SedimentExtractor";
}
