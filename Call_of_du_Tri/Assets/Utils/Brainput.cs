using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Brainput{

	public static float GetAxis(int controller, int axis){
		return Input.GetAxis("joystick " + controller + " analog " + axis);
	}
	public static bool GetButton(int controller, int button){
		return Input.GetButton("joystick " + controller + " button " + button);
	}
	public static bool GetButtonDown(int controller, int button){
		return Input.GetButtonDown("joystick " + controller + " button " + button);
	}
	public static bool GetButtonUp(int controller, int button){
		return Input.GetButtonUp("joystick " + controller + " button " + button);
	}

	public static float[] GetAxes(int controller, params int[] axes){
		float[] values = new float[axes.Length];
		for (int a = 0; a < axes.Length; a++){
			values[a] = GetAxis(controller, axes[a]);
		}
		return values;
	}
	public static bool[] GetButtons(int controller, params int[] buttons){
		bool[] values = new bool[buttons.Length];
		for (int a = 0; a < buttons.Length; a++){
			values[a] = GetButton(controller, buttons[a]);
		}
		return values;
	}
	public static bool[] GetButtonsDown(int controller, params int[] buttons){
		bool[] values = new bool[buttons.Length];
		for (int a = 0; a < buttons.Length; a++){
			values[a] = GetButtonDown(controller, buttons[a]);
		}
		return values;
	}
	public static bool[] GetButtonsUp(int controller, params int[] buttons){
		bool[] values = new bool[buttons.Length];
		for (int a = 0; a < buttons.Length; a++){
			values[a] = GetButtonUp(controller, buttons[a]);
		}
		return values;
	}
	public static bool GetAnyButtons(int controller, params int[] buttons){
		for (int a = 0; a < buttons.Length; a++){
			if(GetButton(controller, buttons[a]))
				return true;
		}
		return false;
	}
	public static bool GetAnyButtonsDown(int controller, params int[] buttons){
		for (int a = 0; a < buttons.Length; a++){
			if(GetButtonDown(controller, buttons[a]))
				return true;
		}
		return false;
	}
	public static bool GetAnyButtonsUp(int controller, params int[] buttons){
		for (int a = 0; a < buttons.Length; a++){
			if(GetButtonUp(controller, buttons[a]))
				return true;
		}
		return false;
	}

	public static Vector2 GetJoystick(int controller){
		float[] values = GetAxes(controller, 0, 1);
		return new Vector2(values[0], values[1]);
	}

}
