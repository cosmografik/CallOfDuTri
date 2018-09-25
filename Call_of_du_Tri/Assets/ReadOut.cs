using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadOut : MonoBehaviour {

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		int percentage = Mathf.FloorToInt(100.0f*((float)Score.record.downdoots/(float)((float)Score.record.updoots+Score.record.downdoots)));
		string timestring = string.Format("Plastic: {0:D2}%", percentage);
		text.text = timestring;
	}
}
