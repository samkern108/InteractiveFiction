using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStore {

	static DataStore self;

	public static List<RoomJSON> RoomsInMemory;
	public static List<ItemJSON> ItemsInMemory;
	public static List<NPCJSON> NPCsInMemory;

	public DataStore()
	{
		RoomsInMemory = new List<RoomJSON> ();
		ItemsInMemory = new List<ItemJSON> ();
		NPCsInMemory = new List<NPCJSON> ();
		self = this;
	}

	public void AddRoomToMemory(RoomJSON r)
	{
		RoomsInMemory.Add (r);
	}

	public void AddItemToMemory(ItemJSON r)
	{
		ItemsInMemory.Add (r);
	}

	public void AddNPCToMemory(NPCJSON r)
	{
		NPCsInMemory.Add (r);
	}
}