using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Handle : MonoBehaviour {

	private List<RoomOutline> rooms;

	void Start()
	{
		rooms = new List<RoomOutline> ();
	}

	public void AddRoomOutline()
	{
		rooms.Add (this.GetComponentInParent<RoomOutline> ());
	}

	public void OnMouseDown() {
		LevelManager.self.CloseRoom (this);
	}

	public void OnMouseDrag()
	{
		if (rooms.Count > 0) {
			foreach(RoomOutline room in rooms) {
				room.UpdateHandlePositions ();
			}
		}
	}
}
