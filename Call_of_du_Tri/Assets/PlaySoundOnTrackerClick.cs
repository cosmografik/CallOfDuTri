using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrackerClick : MonoBehaviour {

	AudioSource aSource;

	void Start () {
		aSource = GetComponent<AudioSource>();
		AimTracker.OnTrackerClick += PlaySound;
	}

	void OnDestroy () {
		AimTracker.OnTrackerClick -= PlaySound;
	}

	void PlaySound(Vector3 _, int __){
		aSource.Play();
	}
}
