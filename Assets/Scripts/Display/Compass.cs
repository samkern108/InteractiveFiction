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
	}

	void FixedUpdate() 
	{
		draw = true;
	}

	public void ClearCompass()
	{
		textList = new List<CompassTextObject> ();
	}

	public void LoadCompassObjects(FixtureInfo[] f)
	{
		ClearCompass ();
		for(int i = 0; i < f.Length; i++)	
			NewTextObject (f[i].nameFancy, f[i].midpoint);
	}

	public void LoadCompassObjects(List<FixtureInfo> f)
	{
		ClearCompass ();
		for(int i = 0; i < f.Count; i++)	
			NewTextObject (f[i].nameFancy, f[i].midpoint);
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

			if (angle <= 90 && angle >= -90) {

				float opacity = 0;
				if (dist < 400) {
					opacity = 15 * (80/dist);
				}

				float textPosition = angle;

				t.myText.color = new Color(t.myText.color.r, t.myText.color.g, t.myText.color.b, (int)(255/opacity));
				t.myText.fontSize = (int)(opacity > 60 ? 60 : opacity);
				t.myText.transform.localPosition = new Vector3 (textPosition.Map(-90, 90, -280, 280), 0, 0);
			}
			else {
				t.myText.color = new Color(0,0,0,0);
			}
		}
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
