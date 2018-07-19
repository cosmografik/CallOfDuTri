using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnShot : MonoBehaviour {

	Renderer rend;
	bool doFlash = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		AimTracker.OnTrackerClick += Flash;
	}
	void OnDestroy () {
		AimTracker.OnTrackerClick -= Flash;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		rend.enabled = doFlash;
		doFlash = false;
	}

	void Flash(Vector3 _, int __){
		doFlash = true;
	}

}
