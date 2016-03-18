using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptPrefab : MonoBehaviour {

	public static Text prompt;

	void Start () 
	{
		prompt = this.GetComponent ("Text") as Text;
		prompt.enabled = false;
	}

	public static void DisplayPrompt(Prompt p)
	{
		prompt.text = "- " + p.text + " -";
		prompt.enabled = true;
	}

	public static void HidePrompt()
	{
		prompt.enabled = false;
	}
}
