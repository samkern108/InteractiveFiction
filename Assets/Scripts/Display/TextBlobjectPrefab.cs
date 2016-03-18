using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBlobjectPrefab : MonoBehaviour {

	private Text myTextObject;

	private float startDelay = 0;
	private float aliveTime = 0;

	private TextBlobject blobject;
	private TextBlobState currentBlobState;
	private int blobStateIterator = 0;
	private ArrayList blobStates = new ArrayList();

	private Font myFont;
	private float mySize;

	public void InitializeBlob(GameObject myself, string text, ArrayList blobStates)
	{
		this.myTextObject = myself.GetComponent<Text> ();
		this.myTextObject.text = text;
		this.blobStates = blobStates;
		if (blobStates.Count > 0) {
			currentBlobState = (TextBlobState)blobStates [0];
		}
		UpdateAttributesForCurrentBlobState ();
	}

	public void AddBlobStateAfterLast(TextBlobState state)
	{
		if (blobStates.Count == 0) {
			currentBlobState = state;
		}
		blobStates.Add(state);
	}
	
	public bool UpdateSelf(float dt) 
	{
		this.aliveTime += dt;

		if (aliveTime >= currentBlobState.deathTime) {
			blobStateIterator++;
			if (blobStateIterator >= blobStates.Count) {
				return true;
			}
			currentBlobState = (TextBlobState)blobStates[blobStateIterator];
			UpdateAttributesForCurrentBlobState();
		}

		return false;
	}

	private void UpdateAttributesForCurrentBlobState()
	{
		//figure out the interpolation
		myTextObject.color = Palette.palette[currentBlobState.color];
		transform.position = new Vector3(currentBlobState.percentx * Camera.main.pixelWidth,currentBlobState.percentz * Camera.main.pixelHeight,0);
	}
}
