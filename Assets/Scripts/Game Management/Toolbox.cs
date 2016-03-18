using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public struct Position
{
	public Vector2 posV;
	public Vector2 dirV;
	public float angle;

	public Position(Vector2 positionVector, Vector2 directionVector, float angle)
	{
		this.posV = positionVector;
		this.dirV = directionVector;
		this.angle = angle;
	}
	
	public void MoveWithSpeed(float speed)
	{
		posV = this.posV + this.dirV * speed;
	}

	public void RotateToAngle(float angleR)
	{
		dirV.x = Vector2.up.x * Mathf.Cos(angleR) - Vector2.up.y * Mathf.Sin(angleR);
		dirV.y = Vector2.up.x * Mathf.Sin(angleR) + Vector2.up.y * Mathf.Cos(angleR);
		angle = angleR;
	}
}

public enum Button
{
	a, s, d, f
}

public class Toolbox : MonoBehaviour {


}
