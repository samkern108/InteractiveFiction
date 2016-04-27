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

	public static Dictionary<string, Condition> activeConditions;
	public static List<string> increasingConditions;

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
		activeConditions = new Dictionary<string, Condition> ();

		roomStates = IOManager.LoadRoomStates ();
		playerState = IOManager.LoadPlayerState ();
		worldState = IOManager.LoadWorldState ();
		worldConstants = IOManager.LoadWorldConstants ();

		WorldClock.SetDate (worldState.clock);
		WeatherSystem.SetWeather (worldState.weather);

		foreach(Condition c in playerState.conditions.Values) {
			DataStore.AddCondition (c);
		}
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

	public static void RemoveConditions(Dictionary<string, Condition> names)
	{
		foreach (string c in names.Keys) {
			activeConditions.Remove (c);	
		}
	}

	public static void RemoveCondition(string name)
	{
		activeConditions.Remove (name);
	}

	public static void AddCondition(Condition c)
	{
		activeConditions.Add (c.name, c);
	}

	public static void AddConditions(List<Condition> cs)
	{
		foreach (Condition c in cs) {
			activeConditions.Add (c.name, c);	
		}
	}

	public static float GetConditionValue(string name)
	{
		if (activeConditions.ContainsKey (name))
			return activeConditions [name].value;
		else {
			Debug.LogError ("Condition " + name + " is unknown; cannot get.");
			return 0;
		}
	}

	//I still don't really know what to do with increase, but we'll figure it out
	public static void IncConditionValue(string name, float inc)
	{
		if (activeConditions.ContainsKey (name)) {
			activeConditions [name].value += inc;
		}
		else {
			Debug.LogError ("Condition " + name + " is unknown; cannot inc.");
		}
	}

	public static void SetConditionValue(string name, float value_eq)
	{
		if (activeConditions.ContainsKey (name)) {
			activeConditions [name].value = value_eq;
		} else {
			Debug.LogError ("Condition " + name + " is unknown; cannot set.");
		}
	}

	public static void SetConditionIncrease(string name, float increase)
	{
		activeConditions [name].increase = increase;
		if (increase == 0) {
			increasingConditions.Remove (name);
		} else if(!increasingConditions.Contains(name)) {
			increasingConditions.Add (name);
		}
	}
}