using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bound : MonoBehaviour {

	private BoundInfo info;
	private Jukebox jukebox;
	private Fixture myFixture;

	public void Initialize(BoundInfo info, Fixture fix)
	{
		this.myFixture = fix;
		this.info = info;
		this.transform.localScale = new Vector3(info.radius * 2, info.radius * 2, 1);
		this.transform.localPosition = new Vector3 ();
		GetComponent <CircleCollider2D> ().isTrigger = this.info.passable;
		if (!this.info.passable) {
			gameObject.layer = LayerMask.NameToLayer ("Impassable");
		}
	}

	public void SetJukebox(Jukebox juke)
	{
		jukebox = juke;
	}
		
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Enter ();
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Enter ();
		}
	}

	private void Enter()
	{
		DisplayText.SetDisplayText (DetermineTextToDisplay());

		if(jukebox != null) {
			jukebox.Play ();
		}
	}

	private string DetermineTextToDisplay()
	{
		string text = "";
		float val = 0;

		foreach (TextCondition tc in info.textConditions) {
			val = DataStore.GetConditionValue (tc.name);
			foreach (TextInterval i in tc.intervals) {
				if (val >= i.start) {
					text += " " + i.text;
					if (i.prompt != null) {
						PromptPrefab.DisplayPrompt (i.prompt, this);
					}
					break;
				}	
			}
		}

		return text;
	}

	private void Exit()
	{
		DisplayText.ClearDisplayText ();

		PromptPrefab.HidePrompt ();

		if(jukebox != null) {
			jukebox.StopPlaying ();
		}
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Exit ();
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Exit ();
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Player") {
			if (jukebox != null) {
				jukebox.AdjustVolumeForDistance (transform.position, collider.transform.position, info.radius * 2);
			}
		}
	}

	public void ToggleVisuals()
	{
		GetComponent <SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
	}
}
