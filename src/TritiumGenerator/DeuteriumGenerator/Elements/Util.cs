using System;
using UnityEngine;

namespace Elements
{
	// Token: 0x02000007 RID: 7
	public static class Util
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002744 File Offset: 0x00000944
		public static Texture2D DuplicateTexture(Texture2D source)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, 7, 1);
			Graphics.Blit(source, temporary);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			Texture2D texture2D = new Texture2D(source.width, source.height);
			texture2D.ReadPixels(new Rect(0f, 0f, (float)temporary.width, (float)temporary.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			return texture2D;
		}
	}
}
