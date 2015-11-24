using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

	public GameObject compassTextPrefab;
	public List<CompassTextObject> textList = new List<CompassTextObject>();

	void Start () {
		UpdateCompassObjects ();
	}

	public void UpdateCompassObjects()
	{
		NewTextObject ("Fireplace", new Vector2(10,0));
		//NewTextObject ("Door", new Vector2(100, 0));
	}

	private void DrawObjects() {
		foreach (CompassTextObject t in textList) {
			Vector2 distToMidpoints = t.mid - Player.position.posV;
			Vector2 directions = Player.position.dirV;

			float dist = Vector2.Distance(Player.position.posV, t.mid);
			float angle = Mathf.DeltaAngle(Mathf.Atan2(directions.y, directions.x) * Mathf.Rad2Deg,
			                               Mathf.Atan2(distToMidpoints.y, distToMidpoints.x) * Mathf.Rad2Deg);

			Debug.Log ("PLAYER -  p:  " + Player.position.posV);
			Debug.Log ("FIREPLACE:  " + t.mid.x + " , " + t.mid.y + " ::  " + dist);
			
			Debug.Log ("Look Dir:  " + Player.position.dirV  + "  angle:  " + angle);

			if (angle < 0) {
				float opacity = 0;
				if (dist < 400) {
					opacity = 15 * (80/dist);
				}

				float textPosition = angle;

				t.myText.color = new Color(t.myText.color.r, t.myText.color.g, t.myText.color.b, (int)(255/opacity));
				t.myText.fontSize = (int)(opacity > 60 ? 60 : opacity);
				t.myText.transform.localPosition = new Vector3 (Map(textPosition, -180, 0, -280, 280), 15, 0);
			}
		}
	}

	private float Map(float s, float a1, float a2, float b1, float b2){
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

	public void NewTextObject(string text, Vector2 midpoint) {
		Debug.Log ("New Text Object:  " + text);
		CompassTextObject t = Instantiate (compassTextPrefab).GetComponent ("CompassTextObject") as CompassTextObject;
		t.gameObject.transform.SetParent (this.gameObject.transform, true);
		t.gameObject.transform.localPosition = new Vector2 (0,15);
		t.Instantiate (midpoint, text);
		textList.Add (t);
	}
	
	public void playerMoved() {
		DrawObjects ();
	}

	public void playerTurned() {
		DrawObjects ();
	}
}
