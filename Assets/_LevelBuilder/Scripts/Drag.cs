using UnityEngine;
using System.Collections;

namespace LevelBuilder {

public class Drag : MonoBehaviour {

	void OnMouseDrag()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = 5;
		this.transform.position = Camera.main.ScreenToWorldPoint(pos);
	}
}
}
