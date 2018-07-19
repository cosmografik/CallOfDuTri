using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerPoint : MonoBehaviour {


	public int player;
	public GameObject hitMarker;
	public GameObject goodHitMarker;
	public float upForce = 3;
	public float pushForce = 3;
	public float torque = 3;

	// Use this for initialization
	void Start () {
		// Listen for Tracker Move events
		AimTracker.OnTrackerMove += MoveMe;
		AimTracker.OnTrackerClick += Shoot;
	}
	
	// CLEAN!
	void OnDestroy(){
		// We're dead, stop listening for Tracker Move events
		AimTracker.OnTrackerMove -= MoveMe;
		AimTracker.OnTrackerClick -= Shoot;
	}

	// This has the same signature as "AimTrackerEvent" in the AimTracker.cs file
	// So we can use it to listen for AimTrackerEvent broadcasts
//	void        Vector3    int
//  vvvv        vvvvvvv    vvv
	void MoveMe(Vector3 p, int pnum){
		if (pnum == this.player){
			p.z = 1;
			p = AimTracker.AxesToScreen(p);
			p = Camera.main.ScreenToWorldPoint(p);
			transform.position = p;
		}
	}

	void Shoot(Vector3 p, int num){
		if (num == this.player){
			p.z = 1;
			p = AimTracker.AxesToScreen(p);
			Debug.Log(p);
			Ray r = Camera.main.ScreenPointToRay(p);
			RaycastHit rch;
			if (Physics.Raycast(r, out rch)){
				Rigidbody rb = rch.collider.GetComponent<Rigidbody>();
				if (rb!=null){
					Vector3 pulse = Vector3.up * upForce + r.direction.normalized * pushForce;
					rb.AddForce(pulse, ForceMode.Impulse);
					rb.AddTorque(Quaternion.AngleAxis(Random.Range(torque, -torque), Random.onUnitSphere).eulerAngles);
					if (!rb.isKinematic)
						GameObject.Instantiate(goodHitMarker, rch.point, Quaternion.LookRotation(rch.normal, Random.onUnitSphere));
				}
				GameObject.Instantiate(hitMarker, rch.point, Quaternion.LookRotation(rch.normal, Random.onUnitSphere));
			}
		}
	}

}
