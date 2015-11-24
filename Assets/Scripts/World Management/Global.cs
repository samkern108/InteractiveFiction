using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

	//Color palette
	public static Dictionary<string, Color> palette;

	void Start()
	{
		palette = new Dictionary<string, Color>();
		palette.Add ("somberGray", new Color(.45f, .5f,.6f,1f));
		palette.Add ("somberBlueGray", new Color(.2f, .2f,.6f,1f));
	}

	//Game Constants
	public const int framerate = 60;


	//Useful Structs
	public struct Point
	{
		public int x;
		public int z;

		public Point(int x, int z)
		{
			this.x = x;
			this.z = z;
		}
	}

	public enum Button
	{
		a, s, d, f
	}


	public class Position
	{
		public Vector2 posV;
		public Vector2 dirV;

		public Position()
		{
			this.posV = new Vector2();
			this.dirV = new Vector2();
		}
		
		public Position(Vector2 positionVector, Vector2 directionVector)
		{
			this.posV = positionVector;
			this.dirV = directionVector;
		}

		public Vector2 MoveWithSpeed(float multiplier)
		{
			return (this.posV + this.dirV * multiplier);
		}
	}
}
