using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Palette : MonoBehaviour {

	//Color palette
	public static Dictionary<string, Color> palette;
	
	void Start()
	{
		palette = new Dictionary<string, Color>();
		palette.Add ("somberGray", new Color(.45f, .5f,.6f,1f));
		palette.Add ("somberBlueGray", new Color(.2f, .2f,.6f,1f));
	}
}
