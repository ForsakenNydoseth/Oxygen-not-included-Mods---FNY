using System;
using Elements;
using Harmony;
using TUNING;
using UnityEngine;

namespace CookingStationPropane
{
	// Token: 0x02000006 RID: 6
	internal class CookingStationConfig1231
	{
		// Token: 0x02000011 RID: 17
		public static class Mod
		{
			// Token: 0x02000014 RID: 20
			[HarmonyPatch(typeof(CookingStationConfig), "CreateBuildingDef")]
			public static class PropaneStationP1
			{
				// Token: 0x06000032 RID: 50 RVA: 0x00003255 File Offset: 0x00001455
				public static void Postfix(BuildingDef __result)
				{
					__result.InputConduitType = 1;
					__result.UtilityInputOffset = new CellOffset(-1, 1);
					__result.OutputConduitType = 2;
					__result.UtilityOutputOffset = new CellOffset(-1, 0);
				}
			}

			// Token: 0x02000015 RID: 21
			[HarmonyPatch(typeof(CookingStationConfig), "ConfigureBuildingTemplate")]
			public static class PropaneStationP2
			{
				// Token: 0x06000033 RID: 51 RVA: 0x00003280 File Offset: 0x00001480
				public static void Postfix(ref GameObject go)
				{
					CookingStation cookingStation = EntityTemplateExtensions.AddOrGet<CookingStation>(go);
					Storage storage = EntityTemplateExtensions.AddOrGet<Storage>(go);
					storage.showInUI = true;
					storage.showDescriptor = true;
					storage.storageFilters = STORAGEFILTERS.GASES;
					storage.capacityKg = 100f;
					Storage storage2 = EntityTemplateExtensions.AddOrGet<Storage>(go);
					storage2.showInUI = true;
					storage2.showDescriptor = true;
					storage2.storageFilters = STORAGEFILTERS.LIQUIDS;
					storage2.capacityKg = 100f;
					ConduitConsumer conduitConsumer = EntityTemplateExtensions.AddOrGet<ConduitConsumer>(go);
					conduitConsumer.capacityTag = GameTagExtensions.CreateTag(-1858722091);
					conduitConsumer.conduitType = 1;
					conduitConsumer.capacityKG = 10f;
					conduitConsumer.storage = storage;
					conduitConsumer.alwaysConsume = true;
					conduitConsumer.forceAlwaysSatisfied = true;
					ConduitDispenser conduitDispenser = EntityTemplateExtensions.AddOrGet<ConduitDispenser>(go);
					conduitDispenser.storage = storage2;
					conduitDispenser.conduitType = 2;
					conduitDispenser.elementFilter = new SimHashes[]
					{
						tagMyElement.TARSimHash
					};
					conduitDispenser.alwaysDispense = true;
					ElementConverter elementConverter = EntityTemplateExtensions.AddOrGet<ElementConverter>(go);
					elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
					{
						new ElementConverter.ConsumedElement(GameTagExtensions.CreateTag(-1858722091), 0.01f)
					};
					elementConverter.outputElements = new ElementConverter.OutputElement[]
					{
						new ElementConverter.OutputElement(0.009f, tagMyElement.TARSimHash, 400.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0)
					};
					BuildingTemplates.CreateComplexFabricatorStorage(go, cookingStation);
				}
			}
		}
	}
}
