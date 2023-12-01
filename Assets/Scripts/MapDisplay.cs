using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour {

	public Renderer textureRender;
	public MeshFilter meshFilter;
	public MeshRenderer meshRenderer;

	//draws the textures on the screen

	public void DrawTexture(Texture2D texture) {
        // Destroy the old texture before assigning a new one
        if (textureRender.sharedMaterial.mainTexture != null)
        {
            Destroy(textureRender.sharedMaterial.mainTexture);
        }
        textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3 (texture.width, 1, texture.height);
	}

	public void DrawMesh(MeshData meshData, Texture2D texture) {
        // Destroy the old mesh before assigning a new one
        if (meshFilter.sharedMesh != null)
        {
            Destroy(meshFilter.sharedMesh);
        }

        meshFilter.sharedMesh = meshData.CreateMesh ();
        // Destroy the old texture before assigning a new one
        if (meshRenderer.sharedMaterial.mainTexture != null)
        {
            Destroy(meshRenderer.sharedMaterial.mainTexture);
        }
        meshRenderer.sharedMaterial.mainTexture = texture;

		

    }

}



