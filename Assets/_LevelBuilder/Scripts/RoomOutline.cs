using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomOutline : MonoBehaviour {
	
	Mesh mesh;

	public void UpdateHandlePositions()
	{
		Handle[] h = this.GetComponentsInChildren<Handle>();
		Vector3[] handles = new Vector3[h.Length];
		
		for(int i = 0; i < handles.Length; i++){
			handles[i] = h[i].transform.position;
		}
		mesh.vertices = handles;
	}

	public void UpdateTriangles()
	{
		Handle[] h = this.GetComponentsInChildren<Handle>();
		Vector3[] handles = new Vector3[h.Length];

		for(int i = 0; i < handles.Length; i++){
			handles[i] = h[i].transform.position;
		}

		mesh.vertices = handles;
		int[] triangles = new int[(handles.Length - 2)*3];
		for (int i = 0, j = 0; i < (handles.Length-2)*3; i+=3, j++) {
			triangles[i] = j;
			triangles[i+1] = j+1;
			triangles[i+2] = j+2;
		}
		mesh.triangles = triangles;

		mesh.uv=new Vector2[mesh.vertices.Length];
		mesh.RecalculateNormals();
		mesh.Optimize();
	}

	public void InstantiateMesh ()
	{
		mesh=new Mesh();
		MeshRenderer renderer=gameObject.AddComponent<MeshRenderer>();
		MeshFilter filter=gameObject.AddComponent<MeshFilter>();

		renderer.material=new Material(Shader.Find("Hidden/Internal-Colored"));
		renderer.material.color=Color.white;

		filter.mesh=mesh;
	}
}
