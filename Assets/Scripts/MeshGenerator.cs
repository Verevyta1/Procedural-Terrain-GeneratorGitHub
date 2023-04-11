using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public static class MeshGenerator {

	//generates the mesh and creates all the triangles and vertecies from the height and width values
	public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve heightCurve, int levelOfDetail) {
		int width = heightMap.GetLength (0);
		int height = heightMap.GetLength (1);
		
		float topLeftX = (width - 1) / -2f;
		float topLeftZ = (height - 1) / 2f;

		//For custom size level of detail will always be 1
		//min
        //128x128(127x127) : 120 -> 121
        //256x256(255x255) : 240 -> 241
        //512x512(511x511) : 504 -> 505
        //1024x1024(1023x1023) : 1020 -> 1021
        //2048x2048(2047x2047) : 2040 -> 2041
        //4096x4096(4095x4095) : 4080 -> 4081
        //8192x8192(8191x8191) : 4160 -> 4161
		//"max"

		//to add exception catch

        int meshSimplificationIncrement = (levelOfDetail == 0) ? 1 : levelOfDetail * 2;
		int verticesPerLine = (width - 1) / meshSimplificationIncrement + 1;
		
		MeshData meshData = new(verticesPerLine, verticesPerLine);
		int vertexIndex = 0;

		for (int y = 0; y < height; y+= meshSimplificationIncrement) {
			for (int x = 0; x < width; x+= meshSimplificationIncrement) {

				meshData.vertices [vertexIndex] = new Vector3 (topLeftX + x, heightCurve.Evaluate(heightMap [x, y]) * heightMultiplier, topLeftZ - y);
				meshData.uvs [vertexIndex] = new Vector2 (x / (float)width, y / (float)height);

				if (x < width - 1 && y < height - 1) {
					meshData.AddTriangle (vertexIndex, vertexIndex + verticesPerLine + 1, vertexIndex + verticesPerLine);
					meshData.AddTriangle (vertexIndex + verticesPerLine + 1, vertexIndex, vertexIndex + 1);
				}

				vertexIndex++;
			}
		}

		return meshData;

	}
}

public class MeshData {
	public Vector3[] vertices;
	public int[] triangles;
	public Vector2[] uvs;

	int triangleIndex;

	public MeshData(int meshWidth, int meshHeight) {
		vertices = new Vector3[meshWidth * meshHeight];
		uvs = new Vector2[meshWidth * meshHeight];
		triangles = new int[(meshWidth-1)*(meshHeight-1)*6];
		
		
	}

	public void AddTriangle(int a, int b, int c) {
		triangles [triangleIndex] = a;
		triangles [triangleIndex + 1] = b;
		triangles [triangleIndex + 2] = c;
		triangleIndex += 3;
	}

	public Mesh CreateMesh() {
		Mesh mesh = new()
		{
			indexFormat = IndexFormat.UInt32,
			vertices = vertices,
			triangles = triangles,
			uv = uvs
		};
        mesh.RecalculateNormals ();
		return mesh;
	}

}