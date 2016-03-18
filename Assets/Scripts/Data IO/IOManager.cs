using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class IOManager
{
	private static string pathToDataFolder;

	public IOManager()
	{
		pathToDataFolder = Application.dataPath + "/Data/";
		LoadPlayerState ();
		LoadRoomStates ();
		LoadWorldConstants ();
		//LoadFlags ();
	}

	public float[] LoadDateArray()
	{
		string data = ReadFromFile ("/mutable/worldState");
		
		DataStore.worldState = JsonConvert.DeserializeObject<WorldState>(data);
		return DataStore.worldState.clock;
	}

	public void LoadWorldConstants()
	{
		string data = ReadFromFile("/world/world_constants");
		DataStore.worldConstants = JsonConvert.DeserializeObject<WorldConstants> (data);
	}

	public void LoadFlags()
	{
		string data = ReadFromFile ("/mutable/flags");
		//DataStore.flags = JsonConvert.DeserializeObject<Flag>(data);
	}

	private string ReadFromFile(string filepath)
	{
		StreamReader streamReader = new StreamReader(pathToDataFolder + filepath + ".json");
		string data = streamReader.ReadToEnd ();
		streamReader.Close();
		return data;
	}

	private void LoadPlayerState()
	{
		string data = ReadFromFile ("/mutable/playerState");
		
		DataStore.playerState = JsonConvert.DeserializeObject<PlayerState>(data);
	}

	private void LoadRoomStates()
	{
		string data = ReadFromFile ("/mutable/roomStates");
		
		DataStore.roomStates = JsonConvert.DeserializeObject<RoomStates>(data);
	}

	public Room LoadRoom(string filename)
	{
		string data = ReadFromFile ("/rooms/"+filename);

		Room newobject = JsonConvert.DeserializeObject<Room>(data);

		foreach(string fref in newobject.fixtures) {
			newobject.fixturesInfo.Add(LoadFixture(fref));
		}

		return newobject;
	}

	private FixtureInfo LoadFixture(string filename)
	{
		string data = ReadFromFile ("/fixtures/"+filename);
		
		FixtureInfo newobject = JsonConvert.DeserializeObject<FixtureInfo>(data);
		return newobject;
	}

	private Item LoadItem(string filename)
	{
		string data = ReadFromFile ("/items/"+filename);
		
		Item newobject = JsonConvert.DeserializeObject<Item>(data);
		return newobject;
	}

	private object LoadNPC(string filename)
	{
		string data = ReadFromFile ("/npcs/"+filename);
		
		NPC newobject = JsonConvert.DeserializeObject<NPC>(data);
		return newobject;
	}
	
	//once again, we should really only need to save a few objects.
	//boolean flags, player state, room map, world state.
	public void SerializeAndSave(object obj, string filename)
	{
		string serialized = JsonConvert.SerializeObject(obj);
	
		StreamWriter streamWriter = new StreamWriter (pathToDataFolder + filename + ".json");

		streamWriter.Write (serialized);
		streamWriter.Flush ();
		streamWriter.Close ();
	}
}
