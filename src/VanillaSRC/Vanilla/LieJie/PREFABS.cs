using System;
using STRINGS;

namespace LieJie
{
	// Token: 0x02000008 RID: 8
	internal class PREFABS
	{
		// Token: 0x02000017 RID: 23
		public class ICEBOX
		{
			// Token: 0x0400001C RID: 28
			public static LocString NAME = UI.FormatAsLink("Icebox", "ICEBOX");

			// Token: 0x0400001D RID: 29
			public static LocString DESC = "Stores your food in quite large quantities";

			// Token: 0x0400001E RID: 30
			public static LocString EFFECT = string.Concat(new string[]
			{
				"将 ",
				UI.FormatAsLink("Food", "FOOD"),
				" 放在里面 ",
				UI.FormatAsLink("Heat", "HEAT"),
				" 以达到保鲜效果."
			});
		}
	}
}
