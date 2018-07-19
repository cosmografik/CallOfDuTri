using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDaUVs : MonoBehaviour {

    public Vector2 scrollSpeed;
    Renderer rend;
    Material material;


	// Use this for initialization
	void Start () {
                rend = GetComponent<Renderer>();
                material = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
                if (material!= null){
                        material.SetTextureOffset("_MainTex", scrollSpeed * Time.time);
                        rend.material = material;
                }
	}
}
