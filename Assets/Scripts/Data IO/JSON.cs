using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


[System.Serializable]
public class TextBlobject
{
	public int delayTime;
	public TextBlobState[] states;
}

[System.Serializable]
public class TextBlobState
{		
	public int percentx;
	public int percentz;
	public string color;	
	public float deathTime;
	public bool interpolateToNext;
}

[System.Serializable]
public class Room
{
	public string name { get; set; }
	public string nameFancy { get; set; }
	public Vector2[] bounds { get; set; }
	public string[] fixtures { get; set; }
	public ItemRef[] items { get; set; }
	//We don't need to worry about serialization problems because we NEVER actually save these objects... only load into them.
	public List<FixtureInfo> fixturesInfo = new List<FixtureInfo>();
	public Dictionary<string, Item> itemMap = new Dictionary<string, Item> ();
}

[System.Serializable]
public class FixtureInfo
{
	public string name { get; set; }
	public string nameFancy { get; set; }
	public bool compass { get; set; }
	public Vector2 midpoint { get; set; }
	public Dictionary<string,Condition> conditions { get; set; }
	public BoundInfo[] bounds { get; set; }
	public JukeboxInfo[] jukeboxes { get; set; }
}

[System.Serializable]
public class Condition
{
	public string name { get; set; }
	public float value { get; set; }
	public float increase { get; set; }
}

[System.Serializable]
public class ItemRef
{
	public string name { get; set; }
	public float quantity { get; set; }
}

[System.Serializable]
public class BoundInfo
{
	public int radius { get; set; }
	public TextCondition[] textConditions { get; set; }
	public bool passable { get; set; }
	public AudioInstr audio { get; set; }
}

[System.Serializable]
public class TextCondition
{
	public string name { get; set; }
	public TextInterval[] intervals { get; set; }
}

[System.Serializable]
public class TextInterval
{
	public float start { get; set; }
	public string text { get; set; }
	public Prompt prompt { get; set; }
	public Exit exit { get; set; }
}

[System.Serializable]
public class Exit
{
	public string endRoom { get; set; }
	public string entrance { get; set; }
	public string flag { get; set; }
}

[System.Serializable]
public class Prompt
{
	public string text { get; set; }
	public string button { get; set; }
	public Condition condition { get; set; }
	public Exit exit {get; set; }
}

[System.Serializable]
public class Item
{
	public string name { get; set; }
	public string nameFancy { get; set; }
	public string text { get; set; }
	public int quantity { get; set; }
}

[System.Serializable]
public class NPC
{
	public string name { get; set; }
	public string nameFancy { get; set; }
	public string text { get; set; }
}

[System.Serializable]
public class PlayerState
{
	public string currentRoom { get; set; }
	public ItemRef[] inventory { get; set; }
	public Dictionary<string, Condition> conditions { get; set; }
}

[System.Serializable]
public class RoomStates
{
	public RoomState[] rooms { get; set; }
}

[System.Serializable]
public class RoomState
{
	public string name { get; set; }
	public List<NPC[]> npcList { get; set; }
}

[System.Serializable]
public class Weather
{
	public float temperature { get; set; }
	public string weatherType { get; set; }
}

[System.Serializable]
public class WorldState
{
	public float[] clock { get; set; }
	public Weather weather { get; set; }
}

[System.Serializable]
public class Coord
{
	public float x { get; set; }
	public float y { get; set; }
}

[System.Serializable]
public class JukeboxInfo
{
	public string name { get; set; }
	public string clip { get; set; }
	public float volume { get; set; }
	public bool auto_play { get; set; }
}

[System.Serializable]
public class AudioInstr
{
	public string jukebox { get; set; }
}
	
[System.Serializable]
public class WorldConstants
{
	public Dictionary<string, string> weatherConstants { get; set; }
	public Dictionary<string, string> seasonConstants { get; set; }
	public Dictionary<string, string> timeConstants { get; set; }
	public Dictionary<string, string> dayConstants { get; set; }
}