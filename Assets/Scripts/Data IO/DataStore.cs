using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum FlagType { STRING, INT, BOOL }

public class Flag {
	public string s;
	public int i;
	public bool b;
}

public class DataStore {

	public static PlayerState playerState;
	public static RoomStates roomStates;
	public static WorldState worldState;

	public static Dictionary<string, Room> rooms;
	public static Dictionary<string, Item> items;
	public static Dictionary<string, NPC> npcs;
	public static Dictionary<string, Flag> flags;

	public static WorldConstants worldConstants;

	public DataStore()
	{
		roomStates = IOManager.LoadRoomStates ();
		playerState = IOManager.LoadPlayerState ();
		worldState = IOManager.LoadWorldState ();
		worldConstants = IOManager.LoadWorldConstants ();

		WorldClock.SetDate (worldState.clock);
		WeatherSystem.SetWeather (worldState.weather);
	}

	public void AddRoomToMemory(Room r)
	{
		rooms.Add (r.name, r);
	}

	public void AddItemToMemory(Item r)
	{
		items.Add (r.name, r);
	}

	public void AddNPCToMemory(NPC r)
	{
		npcs.Add (r.name, r);
	}
}