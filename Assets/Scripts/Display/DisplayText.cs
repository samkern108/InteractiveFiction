using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

	public static Text displayText;

	void Start()
	{
		displayText = GetComponent <Text>();
	}

	public static void SetDisplayText(string text)
	{
		displayText.text = text;
	}

	public static void ClearDisplayText()
	{
		displayText.text = "";
	}
}
