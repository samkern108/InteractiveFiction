using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class IOManager : MonoBehaviour 
{
	private static string pathToDataFolder;

	void Start () 
	{
		pathToDataFolder = Application.dataPath + "/Data/";
	}

	private object LoadAndDeserializeRoom()
	{
		StreamReader streamReader = new StreamReader(pathToDataFolder + "filepath");
		string data = streamReader.ReadToEnd ();
		streamReader.Close();

		RoomJSON newobject = JsonConvert.DeserializeObject<RoomJSON>(data);
		return newobject;
	}

	private object LoadAndDeserializeItem()
	{
		StreamReader streamReader = new StreamReader(pathToDataFolder + "filepath");
		string data = streamReader.ReadToEnd ();
		streamReader.Close();
		
		RoomJSON newobject = JsonConvert.DeserializeObject<RoomJSON>(data);
		return newobject;
	}

	private object LoadAndDeserializeNPC()
	{
		StreamReader streamReader = new StreamReader(pathToDataFolder + "filepath");
		string data = streamReader.ReadToEnd ();
		streamReader.Close();
		
		RoomJSON newobject = JsonConvert.DeserializeObject<RoomJSON>(data);
		return newobject;
	}

	private void SerializeAndSave(object obj)
	{
		string serialized = JsonConvert.SerializeObject(obj);
	
		StreamWriter streamWriter = new StreamWriter (pathToDataFolder + "filepath");

		streamWriter.Write (serialized);
		streamWriter.Flush ();
		streamWriter.Close ();
	}
}
