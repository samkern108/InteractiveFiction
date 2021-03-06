﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bound : MonoBehaviour {

	public static Bound activeBound;
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
		activeBound = this;

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
		if (activeBound == this) {
			DisplayText.ClearDisplayText ();
			activeBound = null;

			PromptPrefab.HidePrompt ();
		}

		if (jukebox != null) {
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

	/*
	 * This is called by ActiveRoomManager by using activeBound to avoid having EVERY bound
	 * get a forceupdate on every world tick.
	 */
	public void UpdateText()
	{
		DisplayText.SetDisplayText (DetermineTextToDisplay());
	}
}
