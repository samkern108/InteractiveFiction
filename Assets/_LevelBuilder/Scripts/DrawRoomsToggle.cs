using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawRoomsToggle : MonoBehaviour {

	Text text;

	void Start()
	{
		text = this.GetComponentInChildren<Text> ();
	}

	public void ToggleDrawRooms()
	{
		LevelManager.self.newRoomMode = !LevelManager.self.newRoomMode;
		if(LevelManager.self.newRoomMode) {
			text.text = "Stop drawing";
		}
		else {
			text.text = "Draw Rooms";
		}
	}
}
