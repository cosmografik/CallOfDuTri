using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDaUVs : MonoBehaviour {

    public Vector2 scrollSpeed;
    Renderer renderer;
    Material material;


	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
        material.SetTextureOffset("_MainTex", scrollSpeed * Time.time);
        renderer.material = material;
	}
}
