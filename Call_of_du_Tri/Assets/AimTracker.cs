using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is what our events look like
public delegate void AimTrackerEvent(Vector3 point, int playerNumber);

public class AimTracker : MonoBehaviour {

	Camera cam;

	// These are all the events
	public static AimTrackerEvent OnTrackerMove;
	public static AimTrackerEvent OnTrackerClick;

	// Update is called once per frame
	void LateUpdate () {
		Vector3 point0 = ScreenToAxes(Input.mousePosition);
		Vector2 point1 = Brainput.GetJoystick(1);
		Vector2 point2 = Brainput.GetJoystick(2);


		if (OnTrackerMove!=null){
			OnTrackerMove(point0, 0);
			OnTrackerMove(point1, 1);
			OnTrackerMove(point2, 2);
		}

		bool pressed1 = Brainput.GetButtonDown(1,0);
		bool pressed2 = Brainput.GetButtonDown(2,0);
		bool pressed0 = Input.GetMouseButtonDown(0);

		if (OnTrackerClick!=null){
			if (pressed0){
				OnTrackerClick(point0, 0);
			}
			if (pressed1){
				OnTrackerClick(point1, 1);
			}
			if (pressed2){
				OnTrackerClick(point2, 2);
			}
		}

	}

	public static Vector3 AxesToScreen(Vector3 a){
		a.x += 1;
		a.x /= 2;
		a.x *= Camera.main.pixelWidth;
		a.y *= -1;
		a.y += 1;
		a.y /= 2;
		a.y *= Camera.main.pixelHeight;
		return a;
	}

	public static Vector3 ScreenToAxes(Vector3 s){
		s.x /= Camera.main.pixelWidth;
		s.x *= 2;
		s.x -= 1;
		s.y /= Camera.main.pixelHeight;
		s.y *= 2;
		s.y -= 1;
		s.y *= -1;
		return s;
	}

}
