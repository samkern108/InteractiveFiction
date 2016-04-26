using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class IOManager
{
	private static string pathToDataFolder;

	public static void Initialize ()
	{
		pathToDataFolder = Application.dataPath + "/Data/";
	}

	public static WorldState LoadWorldState()
	{
		string data = ReadFromFile ("/mutable/worldState");
		return JsonConvert.DeserializeObject<WorldState>(data);
	}

	public static WorldConstants LoadWorldConstants()
	{
		string data = ReadFromFile("/world/world_constants");
		return JsonConvert.DeserializeObject<WorldConstants> (data);
	}

	//Not working
	/*public static void LoadFlags()
	{
		string data = ReadFromFile ("/mutable/flags");
		return JsonConvert.DeserializeObject<Flag>(data);
	}*/

	public static PlayerState LoadPlayerState()
	{
		string data = ReadFromFile ("/mutable/playerState");
		return JsonConvert.DeserializeObject<PlayerState>(data);
	}

	public static RoomStates LoadRoomStates()
	{
		string data = ReadFromFile ("/mutable/roomStates");
		return JsonConvert.DeserializeObject<RoomStates>(data);
	}

	public static Room LoadRoom(string filename)
	{
		string data = ReadFromFile ("/rooms/"+filename);

		Room newobject = JsonConvert.DeserializeObject<Room>(data);

		foreach(string fref in newobject.fixtures) {
			newobject.fixturesInfo.Add(LoadFixture(filename, fref));
		}

		return newobject;
	}

	private static FixtureInfo LoadFixture(string roomName, string filename)
	{
		string data = ReadFromFile ("/rooms/" + roomName + "/"+filename);
		
		FixtureInfo newobject = JsonConvert.DeserializeObject<FixtureInfo>(data);
		return newobject;
	}

	private static Item LoadItem(string filename)
	{
		string data = ReadFromFile ("/items/"+filename);
		
		Item newobject = JsonConvert.DeserializeObject<Item>(data);
		return newobject;
	}

	private static object LoadNPC(string filename)
	{
		string data = ReadFromFile ("/npcs/"+filename);
		
		NPC newobject = JsonConvert.DeserializeObject<NPC>(data);
		return newobject;
	}


	private static string ReadFromFile(string filepath)
	{
		StreamReader streamReader = new StreamReader(pathToDataFolder + filepath + ".json");
		string data = streamReader.ReadToEnd ();
		streamReader.Close();
		return data;
	}
	
	//once again, we should really only need to save a few objects.
	//boolean flags, player state, room map, world state.
	public static void SerializeAndSave(object obj, string filename)
	{
		string serialized = JsonConvert.SerializeObject(obj);
	
		StreamWriter streamWriter = new StreamWriter (pathToDataFolder + filename + ".json");

		streamWriter.Write (serialized);
		streamWriter.Flush ();
		streamWriter.Close ();
	}
}
