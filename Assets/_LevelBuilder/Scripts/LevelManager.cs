using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public static LevelManager self;
	public GameObject handlePrefab;
	public GameObject roomOutlinePrefab;
	public bool newRoomMode = false;
	
	private List<Handle> handles = new List<Handle>();
	
	void Start () {
		self = this;
	}

	void OnMouseDown()
	{
		if (newRoomMode) {
			GameObject handle = Instantiate (handlePrefab);
			handles.Add (handle.GetComponent ("Handle") as Handle);
		
			Vector3 pos = Input.mousePosition;
			handle.transform.position = new Vector3 ((Camera.main.ScreenToWorldPoint (pos)).x, (Camera.main.ScreenToWorldPoint (pos)).y, -2);
		}
	}

	public void CloseRoom(Handle h){
		if (handles.Count > 2 && h.Equals (handles [0])) {
			RoomOutline r = Instantiate(roomOutlinePrefab).GetComponent("RoomOutline") as RoomOutline;
			r.InstantiateMesh();

			foreach(Handle handle in handles)
			{
				handle.transform.SetParent(r.transform);
				handle.AddRoomOutline();
			}

			r.UpdateTriangles();
			handles.Clear ();
		}
	}

	public void NewRoomMode()
	{
		newRoomMode = !newRoomMode;
	}
}
