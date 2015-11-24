using UnityEngine;
using System.Collections;

public class ActiveRoomManager : MonoBehaviour {

	public static RoomJSON activeRoom;

	void Start () 
	{
		activeRoom = new RoomJSON ();
	}

	public static bool DetectCollision(Vector2 pos)
	{
		return true;
	}

	public void worldTick(WorldClock.TimeOfDay obj)
	{
//		Debug.Log ("World Tick:  " + obj.ToString ());
	}

	public void playerMovedToPosition(Global.Position obj) 
	{
		//Debug.Log ("Player Moved:  " + obj.posV);
	}

	public void playerTurnedToPosition(Global.Position obj) 
	{
		//Debug.Log ("Player Turned:  " + obj.dirV);
	}
}
