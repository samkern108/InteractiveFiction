using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	DataStore dataStore;
	SaveManager saveManager;

	void Start () {
		IOManager.Initialize ();
		dataStore = new DataStore ();
		saveManager = new SaveManager ();
		LoadRoom ();
	}

	public void LoadRoom()
	{
		ActiveRoomManager.self.SetActiveRoom(IOManager.LoadRoom (DataStore.playerState.currentRoom));
	}

	public void WorldTick()
	{
		DataStore.IncAllConditions ();
	}
}
