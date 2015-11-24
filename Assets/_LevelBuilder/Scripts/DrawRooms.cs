using UnityEngine;
using System.Collections;

public class DrawRooms : MonoBehaviour {

	private Material mat;
	
	void Start () {
		mat = new Material (Shader.Find ("Hidden/Internal-Colored"));
	}

	void OnPostRender() 
	{
		if (!mat) {
			Debug.LogError("Please Assign a material on the inspector");
			return;
		}
		GL.PushMatrix();
		mat.SetPass(0);
		GL.LoadOrtho();
		GL.Begin (GL.LINES);

		/*for(int i = 0; i < handles.Length; i++){
			GL.Vertex (handles[i].transform.position);
		}
		
		GL.Vertex (handles[0].transform.position);*/
		
		GL.End ();
		GL.PopMatrix ();
		

	}
}
