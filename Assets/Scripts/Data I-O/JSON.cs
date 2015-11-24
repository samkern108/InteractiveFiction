using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


[System.Serializable]
public class TextBlobjectJSON
{
	public int delayTime;
	public List<TextBlobStateJSON> states;
}


[System.Serializable]
public class TextBlobStateJSON
{		
	public int posx;
	public int posz;
	public string color;	
	public float deathTime;
	public bool interpolateToNext;
}


//ROOM

[System.Serializable]
public class RoomJSON
{
	public string name { get; set; }
	public List<JSONCoord> roomBounds { get; set; }
	public List<ExitJSON> exits { get; set; }
	public List<FixtureJSON> fixtures { get; set; }
	public List<ItemRoomLinkJSON> items { get; set; }
	public List<NPCRoomLinkJSON> npcs { get; set; }
}

[System.Serializable]
public class ExitJSON
{
	public string boundName { get; set; }
	public string endRoom { get; set; }
	public string flag { get; set; }
	public string item { get; set; }
	public PromptJSON prompt { get; set; }
}

[System.Serializable]
public class FixtureJSON
{
	public string name { get; set; }
	public JSONCoord midpoint { get; set; }
	public List<BoundJSON> bounds { get; set; }
}

[System.Serializable]
public class BoundJSON
{
	public string name { get; set; }
	public int radius { get; set; }
	public string text { get; set; }
	public bool impassable { get; set; }
	public PromptJSON prompt { get; set; }
}

[System.Serializable]
public class PromptJSON
{
	public string button { get; set; }
	public string text { get; set; }
}


[System.Serializable]
public class ItemsJSON
{
	public List<ItemJSON> allItems;
}

[System.Serializable]
public class ItemJSON
{
	public string name { get; set; }
	public string text { get; set; }
}

[System.Serializable]
public class NPCsJSON
{
	public List<NPCJSON> allNPCs;
}

[System.Serializable]
public class NPCJSON
{
	public string name { get; set; }
	public string text { get; set; }
}


//Links to the actual objects

[System.Serializable]
public class ItemRoomLinkJSON
{
	public string name { get; set; }
	public JSONCoord pos { get; set; }
}

[System.Serializable]
public class NPCRoomLinkJSON
{
	public string name { get; set; }
	public JSONCoord pos { get; set; }
}


//Helpful Structs

[System.Serializable]
public struct JSONCoord
{
	public int x { get; set; }
	public int y { get; set; }
}