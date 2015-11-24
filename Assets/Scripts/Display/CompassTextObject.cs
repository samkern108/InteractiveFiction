using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompassTextObject : MonoBehaviour {

	public Text myText;
	public Vector2 mid;

	public void Instantiate(Vector2 midpoint, string text)
	{
		myText = gameObject.GetComponent ("Text") as Text;
		mid = midpoint;
		myText.text = text;
	}
}
