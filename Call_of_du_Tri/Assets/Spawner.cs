using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationMode{
	SameAsThis,
	Unset,
	Random
}

public class Spawner : MonoBehaviour {

	public GameObject[] items;

	public Vector3 spawnZone = Vector3.one;

	public float spawnPerMinute = 10;

	public RotationMode rotationMode = RotationMode.Unset;

	public bool parentToThis = true;

	public bool preventDoubleSpawn = true;

	int lastSpawn = -1;

	float time;

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime * (spawnPerMinute / 60.0f);
		if (time<=0){
			time += 1;
			int spawnId = Random.Range(0, items.Length);
			while (spawnId == lastSpawn && preventDoubleSpawn && items.Length>1){
				spawnId = Random.Range(0, items.Length);
			}
			GameObject go = GameObject.Instantiate(items[spawnId]);
			lastSpawn = spawnId;
			if (parentToThis){
				go.transform.parent = this.transform;
			}
			go.transform.position = this.transform.position + new Vector3(
				Random.Range(spawnZone.x, -spawnZone.x) / 2,
				Random.Range(spawnZone.y, -spawnZone.y) / 2,
				Random.Range(spawnZone.z, -spawnZone.z) / 2
			);
			switch (rotationMode)
			{
				case RotationMode.SameAsThis:
					go.transform.rotation = this.transform.rotation;
					break;
				case RotationMode.Random:
					go.transform.rotation = Random.rotation;
					break;
				default:
					break;
			}
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, spawnZone);
	}
}
