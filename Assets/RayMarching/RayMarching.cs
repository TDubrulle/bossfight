using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RayMarching : MonoBehaviour {

    Material material;
    public Texture planetTexture;

	void Awake () {
        material = new Material(Shader.Find("Custom/RayMarching"));

        material.SetFloat("radiusSphere", 0.5f);
        material.SetVector("eye", new Vector3(0, 0, -1.5f));
        material.SetVector("front", new Vector3(0, 0, 1));
        material.SetVector("right", new Vector3(1, 0, 0));
        material.SetVector("up", new Vector3(0, 1, 0));
        material.SetTexture("_PlanetTex", planetTexture);
    }
	
    void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}

