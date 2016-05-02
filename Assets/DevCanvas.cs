using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DevCanvas : MonoBehaviour {

	public static Dictionary<string, Room> rooms;

	void Start () {
		rooms = IOManager.LoadAllRooms ();

		foreach(string s in rooms.Keys) {
			Debug.Log ("LOADED KEY: " + s);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
