using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

	public static Text displayText;
	public Color textColor;

	void Start()
	{
		displayText = GetComponent <Text>();
	}

	public static void SetDisplayText(string text)
	{
		displayText.text = text;
	}

	public static void SetTextColor(Color c, bool lerp)
	{
		if (lerp) {
		} else
			textColor = c;
	}

	private IEnumerator LerpTextColor()
	{
		for(int i = 0; i < 10; i++) {
			yield return null;
		}
	}

	public static void ClearDisplayText()
	{
		displayText.text = "";
	}
}
