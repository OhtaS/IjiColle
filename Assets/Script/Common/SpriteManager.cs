using UnityEngine;
using System.Collections;

public static class SpriteManager {
	public static Sprite GetSprite(byte[] bytes, int baseWidth){
		int pos = 16; // 16バイトから開始
		
		int width = 0;
		for (int i = 0; i < 4; i++)
		{
			width = width * 256 + bytes[pos++];
		}
		
		int height = 0;
		for (int i = 0; i < 4; i++)
		{
			height = height * 256 + bytes[pos++];
		}
		
		Texture2D texture = new Texture2D(width, height);
		texture.LoadImage(bytes);

		float size = baseWidth * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSprite(Texture2D texture){
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSprite(Texture2D texture, float baseWidth){
		float size = baseWidth * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSprite(Texture2D texture, Vector2 pivot){
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, size);
		return spriteTexture;
	}

	public static Sprite GetSprite(Texture2D texture, float baseWidth, Vector2 pivot){
		float size = baseWidth * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, size);
		return spriteTexture;
	}

	public static Sprite GetSprite(int width, int height, Color color){
		Texture2D texture = GetTexture (width, height, color);
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}
	
	public static Sprite GetSprite(int width, int height, Color color, Vector2 pivot){
		Texture2D texture = GetTexture (width, height, color);
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, size);
		return spriteTexture;
	}

	public static Sprite SetSpriteTexture(Texture2D texture){
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSpriteTexture(Texture2D texture){
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSpriteTexture(Texture2D texture, Vector2 pivot){
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, size);
		return spriteTexture;
	}

	public static Sprite GetSpriteTexture(int width, int height, Color color){
		Texture2D texture = GetTexture (width, height, color);
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f), size);
		return spriteTexture;
	}

	public static Sprite GetSpriteTexture(int width, int height, Color color, Vector2 pivot){
		Texture2D texture = GetTexture (width, height, color);
		float size = texture.width * (Screen.height/2f) / (float)Screen.width;
		Sprite spriteTexture = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, size);
		return spriteTexture;
	}

	public static Texture2D GetTexture(int width, int height, Color color){
		Texture2D texture;
		texture = new Texture2D(width,height);
		texture.name = "texture";
		for(int y=0;y<height;y++)
			for(int x=0;x<width;x++)
				texture.SetPixel(x,y,color);
		texture.Apply ();
		return texture;
	}
}
