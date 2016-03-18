using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextManager : MonoBehaviour {

	public static Dictionary<string, TextBlobjectPrefab> blobjects;
	public static TextManager instance;
	private ArrayList activeBlobs = new ArrayList();
	public GameObject textBlobPrefab;

	void Start () 
	{
		instance = this;
		blobjects = new Dictionary<string, TextBlobjectPrefab> ();
	}

	public void ConstructBlobState()
	{

	}

	//Figure out how to do callbacks in case the blobject needs to keep being updated
	public void ShowTextBlobWithBlobStates(string text, ArrayList blobStates)
	{
		GameObject blob = Instantiate(textBlobPrefab);
		blob.transform.SetParent (this.gameObject.transform);
		TextBlobjectPrefab blobject = blob.GetComponent<TextBlobjectPrefab> ();
		blobject.InitializeBlob (blob, text, blobStates);
		activeBlobs.Add (blob);
	}

	void Update () 
	{
		UpdateAllBlobs (Time.deltaTime);
	}

	private void UpdateAllBlobs(float dt)
	{
		for(int i = 0; i < activeBlobs.Count; i++)
		{
			GameObject blob = (GameObject)activeBlobs[i];
			TextBlobjectPrefab blobject = blob.GetComponent<TextBlobjectPrefab>();
			bool destroy = blobject.UpdateSelf(dt);
			if(destroy) {
				activeBlobs.Remove(blob);
				Destroy (blob);
			}
		}
	}
}
