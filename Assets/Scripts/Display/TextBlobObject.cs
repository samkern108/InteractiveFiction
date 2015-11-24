using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBlobObject : MonoBehaviour {

	private GameObject myObject;
	private Text myTextObject;

	private float startDelay = 0;
	private float aliveTime = 0;

	private TextBlobjectJSON blobject;
	private TextBlobStateJSON currentBlobState;
	private int blobStateIterator = 0;
	private ArrayList blobStates = new ArrayList();

	private Font myFont;
	private float mySize;

	public void InitializeBlob(GameObject myself, string text, ArrayList blobStates)
	{
		this.myObject = myself;
		this.myTextObject = myself.GetComponent<Text> ();
		this.myTextObject.text = text;
		this.blobStates = blobStates;
		if (blobStates.Count > 0) {
			currentBlobState = (TextBlobStateJSON)blobStates [0];
		}
		UpdateAttributesForCurrentBlobState ();
	}

	public void AddBlobStateAfterLast(TextBlobStateJSON state)
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
			currentBlobState = (TextBlobStateJSON)blobStates[blobStateIterator];
			UpdateAttributesForCurrentBlobState();
		}

		return false;
	}

	private void UpdateAttributesForCurrentBlobState()
	{
		//figure out the interpolation
		myTextObject.color = Global.palette[currentBlobState.color];
		myObject.transform.position = new Vector3(currentBlobState.posx,currentBlobState.posz,0);
	}
}
