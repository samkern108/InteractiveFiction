using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flag {
	public string s;
	public int i;
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
		rooms = new Dictionary<string, Room> ();
		items = new Dictionary<string, Item> ();
		npcs = new Dictionary<string, NPC> ();
		flags = new Dictionary<string, Flag> ();
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