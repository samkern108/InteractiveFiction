using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActions : MonoBehaviour {

	public static Dictionary<string, bool> buttonsDown;

	void Start()
	{
		buttonsDown = new Dictionary<string, bool> ();
		buttonsDown.Add ("d", true);
		buttonsDown.Add ("f", true);
		buttonsDown.Add ("r", true);
		buttonsDown.Add ("g", true);
	}

	void Update () {

		buttonsDown["d"] = Input.GetKeyDown (KeyCode.D);
		buttonsDown["f"] = Input.GetKeyDown (KeyCode.D);
		buttonsDown["r"] = Input.GetKeyDown (KeyCode.D);
		buttonsDown["g"] = Input.GetKeyDown (KeyCode.D);

		/*if (Input.GetKeyDown (KeyCode.D)) {
			buttonsDown["d"] = true;
		} else {
			buttonsDown["d"] = false;
		}
		if(Input.GetKeyDown(KeyCode.F)) {
			buttonsDown["f"] = true;
		} else {
			buttonsDown["f"] = false;
		}
		if(Input.GetKeyDown(KeyCode.R)) {
			buttonsDown["r"] = true;
		} else {
			buttonsDown["r"] = false;
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			buttonsDown ["g"] = true;
		} else {
			buttonsDown ["g"] = false;			
		}*/
	}
}
