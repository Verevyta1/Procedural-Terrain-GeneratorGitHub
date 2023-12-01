using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColourMap, Mesh, FalloffMap};
	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	[Range(0, 6)]
	public int levelOfDetail;
	public float lacunarity;

	public int seed;
	public Vector2 offset;
	public float meshHeightMultiplier;
	public int meshScaleX;
	public int meshScaleZ;
	public AnimationCurve meshHeightCurve;

	public bool autoUpdate;
	public bool useFalloff;

	public TerrainType[] regions;

	float[,] falloffMap;

	public void Awake()
	{
		falloffMap = FalloffGenerator.GenerateFalloffMap(mapWidth, mapHeight);
	}


	public void DrawMapInEditor()
	{

		MapData mapData = GenerateMapData();
        MapDisplay display = FindObjectOfType<MapDisplay>();
		MeshFilter meshFilter = display.GetComponent<MeshFilter>();
		if (meshFilter.sharedMesh != null)
		{
			Destroy(meshFilter.sharedMesh);
		}
		if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(mapData.noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(mapData.colourMap, mapWidth, mapHeight));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(mapData.noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail, meshScaleX, meshScaleZ), TextureGenerator.TextureFromColourMap(mapData.colourMap, mapWidth, mapHeight));
        }
		else if (drawMode == DrawMode.FalloffMap)
		{
			display.DrawTexture(TextureGenerator.TextureFromHeightMap(FalloffGenerator.GenerateFalloffMap(mapWidth, mapHeight)));
			
		}
		
    }

	 MapData GenerateMapData() {
        falloffMap = FalloffGenerator.GenerateFalloffMap(mapWidth, mapHeight);
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
		
		Color32[] colourMap = new Color32[mapWidth * mapHeight];
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				if (useFalloff) {
					noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
				}
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (currentHeight <= regions [i].height) {
						colourMap [y * mapWidth + x] = regions [i].colour;
						break;
					}
				}
			}
		}


		return new MapData(noiseMap, colourMap);
		

	}

    
    void OnValidate() {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}

		falloffMap = FalloffGenerator.GenerateFalloffMap(mapWidth, mapHeight);
		

		
	}
}

[System.Serializable]
public struct TerrainType {
	public string name;
	public float height;
	public Color32 colour;
}

public struct MapData {
	public float[,] noiseMap;
	public Color32[] colourMap;

	//heightMap is noiseMap
	public MapData(float[,] noiseMap, Color32[] colourMap)
	{
		this.noiseMap = noiseMap;
		this.colourMap = colourMap;
	}

}