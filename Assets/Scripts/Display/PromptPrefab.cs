using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptPrefab : MonoBehaviour {

	public static Text promptText;
	private static Prompt prompt;
	private static Bound callback;

	void Start () 
	{
		promptText = this.GetComponent ("Text") as Text;
		promptText.enabled = false;
	}

	void Update()
	{
		if (promptText.enabled && (prompt.button == null || Input.GetButtonDown (prompt.button))) {
			TriggerPrompt ();
			promptText.enabled = false;
		}
	}

	private void TriggerPrompt()
	{
		if (prompt.exit != null) {
			//make sure to check the flag!
			ActiveRoomManager.self.ExitToRoom (prompt.exit.end_room, prompt.exit.entrance);
		}
		if (prompt.condition != null) {
			if (prompt.condition.value != null) {
				DataStore.SetConditionValue (prompt.condition.name, prompt.condition.value);
			}
			if (prompt.condition.inc != null) {
				DataStore.IncConditionValue (prompt.condition.name, prompt.condition.inc);
			}
			if (prompt.condition.increase != null) {
				DataStore.SetConditionIncrease (prompt.condition.name, prompt.condition.increase);
			}
		}
	}

	public static void DisplayPrompt(Prompt p, Bound f)
	{
		prompt = p;
		if (p.button != null) {
			promptText.text = p.button.ToUpper () + " - " + p.text.ToUpper ();
		} else {
			promptText.text = p.text.ToUpper ();
		}
		promptText.enabled = true;
		callback = f;
	}

	public static void HidePrompt()
	{
		promptText.enabled = false;
	}
}
