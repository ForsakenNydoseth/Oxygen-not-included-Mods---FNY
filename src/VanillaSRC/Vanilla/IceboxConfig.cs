using System;
using STRINGS;
using TUNING;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class IceboxConfig : IBuildingConfig
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Icebox";
		int num = 2;
		int num2 = 3;
		string text2 = "vendingmachine_kanim";
		int num3 = 30;
		float num4 = 10f;
		float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
		string[] refined_METALS = MATERIALS.REFINED_METALS;
		float num5 = 800f;
		BuildLocationRule buildLocationRule = 1;
		EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER0;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, refined_METALS, num5, buildLocationRule, BUILDINGS.DECOR.BONUS.TIER1, tier2, 0.2f);
		buildingDef.Floodable = false;
		buildingDef.ViewMode = OverlayModes.Power.ID;
		buildingDef.AudioCategory = "Metal";
		buildingDef.PermittedRotations = 3;
		buildingDef.RequiresPowerInput = true;
		buildingDef.PowerInputOffset = new CellOffset(0, 0);
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		buildingDef.InputConduitType = 1;
		buildingDef.OutputConduitType = 1;
		buildingDef.UtilityOutputOffset = new CellOffset(0, 2);
		buildingDef.EnergyConsumptionWhenActive = 35f;
		buildingDef.SelfHeatKilowattsWhenActive = 0.125f;
		SoundEventVolumeCache.instance.AddVolume("vendingmachine_kanim", "vendingmachine_working", NOISE_POLLUTION.NOISY.TIER2);
		SoundEventVolumeCache.instance.AddVolume("vendingmachine_kanim", "vendingmachine_open", NOISE_POLLUTION.NOISY.TIER2);
		return buildingDef;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000217C File Offset: 0x0000037C
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		EntityTemplateExtensions.AddOrGet<LoopingSounds>(go);
		BuildingTemplates.CreateDefaultStorage(go, false).showInUI = true;
		ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
		conduitConsumer.conduitType = 1;
		conduitConsumer.forceAlwaysSatisfied = true;
		conduitConsumer.consumptionRate = 0.001f;
		conduitConsumer.capacityKG = 1f;
		conduitConsumer.capacityTag = GameTags.Gas;
		ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
		{
			new ElementConverter.ConsumedElement(new Tag("Carbon Dioxide"), 0.01f)
		};
		elementConverter.outputElements = new ElementConverter.OutputElement[]
		{
			new ElementConverter.OutputElement(0.01f, -1554872654, 560.15f, true, true, 2f, 1.5f, 0f, byte.MaxValue, 0)
		};
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002240 File Offset: 0x00000440
	public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x0000224A File Offset: 0x0000044A
	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002254 File Offset: 0x00000454
	public override void DoPostConfigureComplete(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
		EntityTemplateExtensions.AddOrGet<LogicOperationalController>(go);
		EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go);
	}

	// Token: 0x04000001 RID: 1
	public const string ID = "Icebox";

	// Token: 0x04000002 RID: 2
	private static readonly LogicPorts.Port OUTPUT_PORT = LogicPorts.Port.OutputPort(FilteredStorage.FULL_PORT_ID, new CellOffset(0, 2), BUILDINGS.PREFABS.REFRIGERATOR.LOGIC_PORT, BUILDINGS.PREFABS.REFRIGERATOR.LOGIC_PORT_ACTIVE, BUILDINGS.PREFABS.REFRIGERATOR.LOGIC_PORT_INACTIVE, false, false);
}
