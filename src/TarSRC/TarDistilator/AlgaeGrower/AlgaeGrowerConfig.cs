using System;
using TUNING;
using UnityEngine;

namespace AlgaeGrower
{
	// Token: 0x0200000C RID: 12
	public class AlgaeGrowerConfig : IBuildingConfig
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000028BC File Offset: 0x00000ABC
		public override BuildingDef CreateBuildingDef()
		{
			string text = "Algae Grower";
			int num = 1;
			int num2 = 2;
			string text2 = "algaefarm_kanim";
			int num3 = 30;
			float num4 = 30f;
			float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
			string[] all_MINERALS = MATERIALS.ALL_MINERALS;
			float num5 = 800f;
			BuildLocationRule buildLocationRule = 1;
			EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_MINERALS, num5, buildLocationRule, BUILDINGS.DECOR.PENALTY.TIER2, tier2, 0.2f);
			buildingDef.RequiresPowerInput = true;
			buildingDef.PowerInputOffset = new CellOffset(0, 0);
			buildingDef.EnergyConsumptionWhenActive = 27f;
			buildingDef.SelfHeatKilowattsWhenActive = 6.75f;
			buildingDef.AudioCategory = "HollowMetal";
			buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
			buildingDef.InputConduitType = 2;
			buildingDef.UtilityInputOffset = new CellOffset(0, 0);
			buildingDef.ModifiesTemperature = true;
			return buildingDef;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002994 File Offset: 0x00000B94
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
			EntityTemplateExtensions.AddOrGet<BuildingComplete>(go).isManuallyOperated = false;
			Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
			storage.showInUI = true;
			storage.capacityKg = 2000f;
			storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
			Storage storage2 = BuildingTemplates.CreateDefaultStorage(go, false);
			storage2.showInUI = true;
			storage2.capacityKg = 30f;
			storage2.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
			ManualDeliveryKG manualDeliveryKG = EntityTemplateExtensions.AddOrGet<ManualDeliveryKG>(go);
			manualDeliveryKG.allowPause = false;
			manualDeliveryKG.SetStorage(storage2);
			manualDeliveryKG.requestedItemTag = GameTagExtensions.CreateTag(-1870043872);
			manualDeliveryKG.capacity = storage2.capacityKg;
			manualDeliveryKG.refillMass = 0.75f;
			manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FarmFetch.IdHash;
			ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
			conduitConsumer.storage = storage;
			conduitConsumer.conduitType = 2;
			conduitConsumer.consumptionRate = 2f;
			conduitConsumer.capacityTag = GameTagExtensions.CreateTag(1832607973);
			conduitConsumer.wrongElementResult = 1;
			conduitConsumer.capacityKG = 2000f;
			conduitConsumer.forceAlwaysSatisfied = true;
			ElementConsumer elementConsumer = EntityTemplateExtensions.AddOrGet<ElementConsumer>(go);
			elementConsumer.storage = storage;
			elementConsumer.configuration = 0;
			elementConsumer.elementToConsume = 1960575215;
			elementConsumer.capacityKG = 20f;
			elementConsumer.consumptionRate = 0.0283f;
			elementConsumer.consumptionRadius = 3;
			elementConsumer.isRequired = false;
			EntityTemplateExtensions.AddOrGet<Storage>(go);
			storage.showInUI = true;
			ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
			elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
			{
				new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(1832607973), 1f),
				new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(-1870043872), 0.0115f)
			};
			elementConverter.outputElements = new ElementConverter.OutputElement[]
			{
				new ElementConverter.OutputElement(0.0666665f, -1528777920, 295.15f, false, false, 0f, 0.5f, 1f, byte.MaxValue, 0),
				new ElementConverter.OutputElement(0.3333332f, -1870043872, 350.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0)
			};
			ElementDropper elementDropper = EntityTemplateExtensions.AddOrGet<ElementDropper>(go);
			elementDropper.emitMass = 1.95f;
			elementDropper.emitTag = GameTagExtensions.CreateTag(-1870043872);
			elementDropper.emitOffset = new Vector2(0f, 1f);
			Prioritizable.AddRef(go);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000229D File Offset: 0x0000049D
		public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002C0C File Offset: 0x00000E0C
		public override void DoPostConfigureUnderConstruction(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
			LightShapePreview lightShapePreview = go.AddComponent<LightShapePreview>();
			lightShapePreview.lux = 1200;
			lightShapePreview.radius = 5f;
			lightShapePreview.shape = 0;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002C48 File Offset: 0x00000E48
		public override void DoPostConfigureComplete(GameObject go)
		{
			GeneratedBuildings.RegisterSingleLogicInputPort(go);
			EntityTemplateExtensions.AddOrGet<LogicOperationalController>(go);
			EntityTemplateExtensions.AddOrGetDef<PoweredActiveController.Def>(go);
			EntityTemplateExtensions.AddOrGet<LoopingSounds>(go);
			Light2D light2D = EntityTemplateExtensions.AddOrGet<Light2D>(go);
			light2D.overlayColour = LIGHT2D.LIGHTBUG_COLOR_CRYSTAL;
			light2D.Color = LIGHT2D.LIGHTBUG_COLOR_BLUE;
			light2D.Range = 5f;
			light2D.Angle = 3f;
			light2D.Direction = LIGHT2D.CEILINGLIGHT_DIRECTION;
			light2D.Offset = LIGHT2D.CEILINGLIGHT_OFFSET;
			light2D.shape = 0;
			light2D.drawOverlay = true;
			light2D.Lux = 1200;
			EntityTemplateExtensions.AddOrGetDef<LightController.Def>(go);
		}

		// Token: 0x0400000D RID: 13
		public static float totalConversion = 0.4f;

		// Token: 0x0400000E RID: 14
		public static float sulfureConversionRate = 0.05f;

		// Token: 0x0400000F RID: 15
		public const string ID = "AlgaeGrower";
	}
}
