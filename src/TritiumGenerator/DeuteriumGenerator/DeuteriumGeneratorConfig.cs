using System;
using Elements;
using TUNING;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class DeuteriumGeneratorConfig : IBuildingConfig
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Tritium Generator";
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
		buildingDef.GeneratorWattageRating = 4085f;
		buildingDef.GeneratorBaseCapacity = 1200f;
		buildingDef.ExhaustKilowattsWhenActive = 10f;
		buildingDef.SelfHeatKilowattsWhenActive = 2f;
		buildingDef.InputConduitType = 2;
		buildingDef.UtilityOutputOffset = new CellOffset(2, 2);
		buildingDef.ViewMode = OverlayModes.Power.ID;
		buildingDef.AudioCategory = "HollowMetal";
		buildingDef.PowerInputOffset = new CellOffset(1, 0);
		buildingDef.UtilityInputOffset = new CellOffset(0, 0);
		return buildingDef;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002140 File Offset: 0x00000340
	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
		Tag tag = GameTagExtensions.Create(tagMyElement.TritiumSimHash);
		EnergyGenerator energyGenerator = EntityTemplateExtensions.AddOrGet<EnergyGenerator>(go);
		EnergyGenerator energyGenerator2 = energyGenerator;
		EnergyGenerator.Formula formula = default(EnergyGenerator.Formula);
		formula.inputs = new EnergyGenerator.InputItem[]
		{
			new EnergyGenerator.InputItem(tag, 0.0001f, 1f)
		};
		formula.outputs = new EnergyGenerator.OutputItem[]
		{
			new EnergyGenerator.OutputItem(tagMyElement.DeuteriumSimHash, 0.65f, true, 385.15f)
		};
		energyGenerator2.formula = formula;
		energyGenerator.powerDistributionOrder = 8;
		Tag tag2 = GameTagExtensions.Create(tagMyElement.DeuteriumSimHash);
		EnergyGenerator energyGenerator3 = EntityTemplateExtensions.AddOrGet<EnergyGenerator>(go);
		EnergyGenerator energyGenerator4 = energyGenerator3;
		formula = default(EnergyGenerator.Formula);
		formula.inputs = new EnergyGenerator.InputItem[]
		{
			new EnergyGenerator.InputItem(tag2, 0.00038f, 1f)
		};
		formula.outputs = new EnergyGenerator.OutputItem[]
		{
			new EnergyGenerator.OutputItem(tagMyElement.DeuteriumSimHash, 0.65f, true, 385.15f)
		};
		energyGenerator4.formula = formula;
		energyGenerator3.powerDistributionOrder = 8;
		Storage storage = EntityTemplateExtensions.AddOrGet<Storage>(go);
		storage.capacityKg = 1f;
		storage.showInUI = true;
		EntityTemplateExtensions.AddOrGet<LoopingSounds>(go);
		Prioritizable.AddRef(go);
		ManualDeliveryKG manualDeliveryKG = EntityTemplateExtensions.AddOrGet<ManualDeliveryKG>(go);
		manualDeliveryKG.allowPause = false;
		manualDeliveryKG.SetStorage(storage);
		manualDeliveryKG.requestedItemTag = tag;
		manualDeliveryKG.capacity = storage.capacityKg;
		manualDeliveryKG.refillMass = 100f;
		manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.PowerFetch.IdHash;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000022CD File Offset: 0x000004CD
	public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000022D7 File Offset: 0x000004D7
	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		GeneratedBuildings.RegisterSingleLogicInputPort(go);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000022E1 File Offset: 0x000004E1
	public override void DoPostConfigureComplete(GameObject go)
	{
		EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go).showWorkingStatus = true;
	}

	// Token: 0x04000001 RID: 1
	public const string ID = "TritiumGenerator";
}
