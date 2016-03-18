using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomText : MonoBehaviour {

	public static Text roomText;

	void Start()
	{
		roomText = GetComponent <Text>();
	}

	public static void SetRoomText(string text)
	{
		roomText.text = text;
	}
}
