using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour {

	public string goodTag;

	void OnTriggerEnter(Collider col){
		if (col.tag == goodTag){
			Score.record.Bump();
		} else {
			Score.record.Down();
		}
		Destroy(col.gameObject);
	}

}
