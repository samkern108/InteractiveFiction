using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prompt : MonoBehaviour {

	public Text prompt;

	void Start () 
	{
		prompt = this.GetComponent ("Text") as Text;
		prompt.enabled = false;
	}

	public void DisplayPrompt(string text)
	{
		prompt.text = text;
		prompt.enabled = true;
	}

	public void HidePrompt()
	{
		prompt.enabled = false;
	}
}
