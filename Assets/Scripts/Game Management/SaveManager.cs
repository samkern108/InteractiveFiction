using UnityEngine;
using System.Collections;

public class SaveManager {

	public static void Save(object obj)
	{
		//IOManager.self.SerializeAndSave (obj, "fileName");
	}

	const float autosaveTimer = 30f;
	float timeSinceLastSave = 0f;

	/*void FixedUpdate () 
	{
		timeSinceLastSave += Time.deltaTime;

		if (timeSinceLastSave >= autosaveTimer) {
			Debug.Log ("Saving...");
			timeSinceLastSave = 0;
			//Save();
		}
	}*/

	//We'll do saving later because I don't like doing it >_>
	//the only things that should need to be saved are the player state, the world state, game booleans, and the room map
	private void Save()
	{
		//IOManager.self.SerializeAndSave (DataStore.worldState, "worldState");
		//IOManager.self.SerializeAndSave (DataStore.playerState, "playerState");
	}
}
