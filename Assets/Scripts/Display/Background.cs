using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	private Material bgMat;
	public static Background instance;

	void Start()
	{
		bgMat = GetComponent<Renderer> ().material;
		bgMat.SetColor ("_EmissionColor", Color.white);
		instance = this;
	}
	
	public void CloseToWallTint(float distance)
	{
		HSBColor tempColor = new HSBColor (bgMat.color);
		distance = Mathf.Clamp(50 - distance, 0, tempColor.b);
		tempColor.b -= distance;
		bgMat.SetColor ("_EmissionColor", tempColor.ToColor());
	}
}
