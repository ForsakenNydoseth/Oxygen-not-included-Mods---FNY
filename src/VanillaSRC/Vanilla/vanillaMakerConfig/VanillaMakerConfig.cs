using System;
using Elements;
using IceBoxBuilding;
using TUNING;
using UnityEngine;

namespace vanillaMakerConfig
{
	// Token: 0x02000004 RID: 4
	public class VanillaMakerConfig : IBuildingConfig
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000022B8 File Offset: 0x000004B8
		public override BuildingDef CreateBuildingDef()
		{
			string text = "Vanilla Maker";
			int num = 4;
			int num2 = 3;
			string text2 = "vanillamaker_kanim";
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
			buildingDef.OutputConduitType = 2;
			buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
			buildingDef.UtilityOutputOffset = new CellOffset(1, 2);
			buildingDef.ModifiesTemperature = true;
			return buildingDef;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000023A8 File Offset: 0x000005A8
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
			conduitConsumer.consumptionRate = VanillaMakerConfig.totalConversion;
			conduitConsumer.capacityTag = GameTagExtensions.CreateTag(-87974045);
			conduitConsumer.wrongElementResult = 1;
			conduitConsumer.capacityKG = 50f;
			conduitConsumer.forceAlwaysSatisfied = true;
			ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
			conduitDispenser.conduitType = 2;
			conduitDispenser.invertElementFilter = true;
			conduitDispenser.elementFilter = new SimHashes[]
			{
				-87974045
			};
			EntityTemplateExtensions.AddOrGet<Storage>(go);
			storage.showInUI = true;
			ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
			elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
			{
				new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(-87974045), VanillaMakerConfig.totalConversion)
			};
			elementConverter.outputElements = new ElementConverter.OutputElement[]
			{
				new ElementConverter.OutputElement(VanillaMakerConfig.VanillaConversionRate, tagMyElement.VanillaSimHash, 250.15f, false, true, 1f, 1f, 1f, byte.MaxValue, 0)
			};
			Prioritizable.AddRef(go);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002240 File Offset: 0x00000440
		public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000224A File Offset: 0x0000044A
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002254 File Offset: 0x00000454
		public override void DoPostConfigureComplete(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
			EntityTemplateExtensions.AddOrGet<LogicOperationalController>(go);
			EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go);
		}

		// Token: 0x04000003 RID: 3
		public static float totalConversion = 1.1f;

		// Token: 0x04000004 RID: 4
		public static float VanillaConversionRate = VanillaMakerConfig.totalConversion;

		// Token: 0x04000005 RID: 5
		public const string ID = "VanillaExtractor";
	}
}
