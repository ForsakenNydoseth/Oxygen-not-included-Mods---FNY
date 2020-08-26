using System;
using TUNING;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class LithiumBatteryConfig : BaseBatteryConfig
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public override BuildingDef CreateBuildingDef()
	{
		string text = "Lithium Battery";
		int num = 2;
		int num2 = 2;
		int num3 = 300;
		string text2 = "batterymed_kanim";
		float num4 = 60f;
		string[] array = new string[]
		{
			"Lithium",
			"Copper",
			"Aluminum"
		};
		float[] array2 = new float[]
		{
			BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
			BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0],
			BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]
		};
		string[] array3 = array;
		float num5 = 800f;
		float num6 = 0.25f;
		float num7 = 12.75f;
		EffectorValues tier = NOISE_POLLUTION.NOISY.TIER1;
		BuildingDef result = base.CreateBuildingDef(text, num, num2, num3, text2, num4, array2, array3, num5, num6, num7, BUILDINGS.DECOR.PENALTY.TIER2, tier);
		SoundEventVolumeCache.instance.AddVolume("batterymed_kanim", "Battery_med_rattle", NOISE_POLLUTION.NOISY.TIER2);
		return result;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002128 File Offset: 0x00000328
	public override void DoPostConfigureComplete(GameObject go)
	{
		Battery battery = EntityTemplateExtensions.AddOrGet<Battery>(go);
		battery.capacity = 127500f;
		battery.joulesLostPerSecond = 0.125f;
		base.DoPostConfigureComplete(go);
	}

	// Token: 0x04000001 RID: 1
	public const string ID = "BatteryLithium";
}
