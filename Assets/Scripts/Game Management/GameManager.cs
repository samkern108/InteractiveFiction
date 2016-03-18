using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	DataStore dataStore;
	IOManager ioManager;
	SaveManager saveManager;

	void Start () {
	
		dataStore = new DataStore ();
		saveManager = new SaveManager ();
		ioManager = new IOManager ();
		LoadRoom ();
	}

	public void LoadRoom()
	{
		ActiveRoomManager.self.SetActiveRoom(ioManager.LoadRoom ("bedroom"));
	}
}
