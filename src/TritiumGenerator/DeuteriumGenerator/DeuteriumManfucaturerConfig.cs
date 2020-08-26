using System;
using Elements;
using Tritium;
using TUNING;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class DeuteriumManfucaturerConfig : IBuildingConfig
{
	// Token: 0x06000007 RID: 7 RVA: 0x000022FC File Offset: 0x000004FC
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Deuterium Manfucaturer";
		int num = 4;
		int num2 = 3;
		string text2 = "custom_kanim";
		int num3 = 30;
		float num4 = 30f;
		float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
		string[] all_METALS = MATERIALS.ALL_METALS;
		float num5 = 800f;
		BuildLocationRule buildLocationRule = 1;
		EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER5;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_METALS, num5, buildLocationRule, BUILDINGS.DECOR.PENALTY.TIER2, tier2, 0.2f);
		buildingDef.RequiresPowerInput = true;
		buildingDef.EnergyConsumptionWhenActive = 1f;
		buildingDef.ExhaustKilowattsWhenActive = 10f;
		buildingDef.SelfHeatKilowattsWhenActive = 2f;
		buildingDef.ViewMode = OverlayModes.Power.ID;
		buildingDef.AudioCategory = "HollowMetal";
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.InputConduitType = 2;
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		buildingDef.OutputConduitType = 2;
		buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
		return buildingDef;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000023F0 File Offset: 0x000005F0
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		EntityTemplateExtensions.AddOrGet<BuildingComplete>(go).isManuallyOperated = true;
		Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
		storage.showInUI = true;
		storage.capacityKg = 50f;
		storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
		IceBoxConfig iceBoxConfig = EntityTemplateExtensions.AddOrGet<IceBoxConfig>(go);
		ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
		conduitConsumer.conduitType = 2;
		conduitConsumer.consumptionRate = 6f;
		conduitConsumer.capacityTag = GameTagExtensions.CreateTag(1911997537);
		conduitConsumer.wrongElementResult = 1;
		conduitConsumer.capacityKG = 500f;
		conduitConsumer.forceAlwaysSatisfied = true;
		ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
		conduitDispenser.conduitType = 2;
		conduitDispenser.invertElementFilter = true;
		conduitDispenser.elementFilter = new SimHashes[]
		{
			1911997537
		};
		EntityTemplateExtensions.AddOrGet<Storage>(go);
		ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
		elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
		{
			new ElementConverter.ConsumedElement(new Tag("SaltWater"), 6f)
		};
		elementConverter.outputElements = new ElementConverter.OutputElement[]
		{
			new ElementConverter.OutputElement(0.02f, tagMyElement.DeuteriumSimHash, 323.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0),
			new ElementConverter.OutputElement(0.0001f, tagMyElement.TritiumSimHash, 4513f, false, true, 0f, 0.5f, 0f, byte.MaxValue, 0)
		};
		Prioritizable.AddRef(go);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002563 File Offset: 0x00000763
	public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
		base.DoPostConfigurePreview(def, go);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002576 File Offset: 0x00000776
	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
		base.DoPostConfigureUnderConstruction(go);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000022E1 File Offset: 0x000004E1
	public override void DoPostConfigureComplete(GameObject go)
	{
		EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go).showWorkingStatus = true;
	}

	// Token: 0x04000002 RID: 2
	public const string ID = "DeuteriumManfucaturer";
}
