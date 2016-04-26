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

	/*
	 * Right now, the prompt includes
	 * name: name of condition
	 * value_eq: set the value
	 * value_inc: increase the value
	 * increase: increase over time
	 */


	public static float GetConditionValue(string name)
	{
		switch (name) {
		case "temp":
			return worldState.weather.temperature;
			break;
		case "weather":
			//worldState.weather.weatherType;
			return 0;
			break;
		case "time":
			return 0;
			break;
		default:
			if (playerState.conditions.ContainsKey (name))
				return playerState.conditions [name].value;
			break;
		}
		Debug.LogError ("Error: Condition With Name " + name + " Not Found.");
		return 0;
	}

	//I still don't really know what to do with increase, but we'll figure it out
	public static void IncConditionValue(string name, float value_inc, float increase)
	{
		playerState.conditions [name].value += value_inc;
	}

	public static void SetConditionValue(string name, float value_eq, float increase)
	{
		playerState.conditions [name].value = value_eq;
	}
}