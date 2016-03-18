using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

	public static Compass instance;
	public GameObject compassTextPrefab;
	public List<CompassTextObject> textList = new List<CompassTextObject>();

	private bool draw;

	void Start()
	{
		instance = this;
		if (ActiveRoomManager.self != null && !ActiveRoomManager.self.compassInitialized) {
			ActiveRoomManager.self.AddAllCompassFixtures();
		}
	}

	void FixedUpdate() {
		draw = true;
	}

	public void AddCompassObject(FixtureInfo f)
	{
		NewTextObject (f.nameFancy, f.midpoint);
	}

	private void DrawObjects(Position player) {
		foreach (CompassTextObject t in textList) {
			Vector2 distToMidpoints = t.mid - player.posV;
			Vector2 directions = player.dirV;

			float dist = Vector2.Distance(player.posV, t.mid);
			float angle = Mathf.DeltaAngle(Mathf.Atan2(directions.y, directions.x) * Mathf.Rad2Deg,
			                               Mathf.Atan2(distToMidpoints.y, distToMidpoints.x) * Mathf.Rad2Deg);

			//Debug.Log ("FIREPLACE:  " + t.mid.x + " , " + t.mid.y + " ::  " + dist);
			
			//Debug.Log ("Pos:  " + player.posV + "  Look:  " + player.dirV  + "  angle:  " + angle);

			if (angle <= 90 && angle >= -90) {

				float opacity = 0;
				if (dist < 400) {
					opacity = 15 * (80/dist);
				}

				float textPosition = angle;

				t.myText.color = new Color(t.myText.color.r, t.myText.color.g, t.myText.color.b, (int)(255/opacity));
				t.myText.fontSize = (int)(opacity > 60 ? 60 : opacity);
				t.myText.transform.localPosition = new Vector3 (Map(textPosition, -90, 90, -280, 280), 0, 0);
			}
			else {
				t.myText.color = new Color(0,0,0,0);
			}
		}
	}

	private float Map(float s, float a1, float a2, float b1, float b2){
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

	public void NewTextObject(string text, Vector2 midpoint) {
		CompassTextObject t = Instantiate (compassTextPrefab).GetComponent ("CompassTextObject") as CompassTextObject;
		t.gameObject.transform.SetParent (this.gameObject.transform, true);
		t.gameObject.transform.localPosition = new Vector2 (0,15);
		t.Instantiate (midpoint, text);
		textList.Add (t);
	}
	
	public void PlayerMoved(Position pos) {
		if (draw) {
			DrawObjects (pos);
			draw = false;
		}
	}
}
