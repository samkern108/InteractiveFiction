using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveRoomManager : MonoBehaviour {

	public static ActiveRoomManager self;

	private Room activeRoom;
	private int currentRadius;

	public GameObject fixturePrefab;

	public List<Fixture> fixtures;

	public void ForceUpdate()
	{
		AddAllCompassFixtures ();
	}

	void Start()
	{
		self = this;
	}

	public void ExitToRoom (string endRoom, string entrance)
	{
		Debug.Log (endRoom);
		//TODO gotta move the player as well
		ClearCurrentRoom();
		SetActiveRoom (IOManager.LoadRoom (endRoom));
	}

	private void ClearCurrentRoom()
	{
		Compass.instance.ClearCompass ();
		for (int i = 0; i < fixtures.Count; i++) {
			Destroy (fixtures[i].gameObject);
		}
	}

	public void SetActiveRoom(Room room)
	{
		Fixture fixture;
		activeRoom = room;

		RoomText.SetRoomText (room.nameFancy);

		fixtures = new List<Fixture> ();
		for(int i = 0; i < activeRoom.fixturesInfo.Count; i++)
		{
			fixture = Instantiate (fixturePrefab).GetComponent <Fixture> ();
			fixture.Initialize (activeRoom.fixturesInfo [i]);
			fixture.transform.parent = transform;
			fixtures.Add (fixture);
		}
		AddAllCompassFixtures ();
		PolygonTools.InitializeRoom (room.bounds);
		//InitializePolygonCollider ();
	}

	/**
	 * 
	 */
	public void AddAllCompassFixtures()
	{
		foreach(Fixture f in fixtures) {
			Compass.instance.NewTextObject (f.name(), f.midpoint());
		}
	}

	public void DistanceFromWall(Position pos)
	{
		Background.instance.CloseToWallTint (10f);
	}

	/**
	 * Returns true if the player is inside the room; false otherwise.
	 */
	public bool PlayerInsideRoom(Vector2 playerPosition)
	{
		return PolygonTools.PointInPolygon (playerPosition);
	}

	public void worldTick(TimeOfDay obj)
	{
	}

	private void InitializePolygonCollider() {
		PolygonCollider2D pc2d = GetComponent <PolygonCollider2D>();
		pc2d.points = activeRoom.bounds;

		/*MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
		renderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));
		renderer.material.color=Color.cyan;

		MeshFilter filter=gameObject.AddComponent<MeshFilter>();
		Mesh mesh=new Mesh();

		Vector3[] bounds = Vector3(activeRoom.bounds);

		mesh.vertices = activeRoom.bounds;
		//mesh.triangles = constructTrianglesFromVertices(vertices);
		    
		mesh.RecalculateNormals();
		mesh.Optimize();
		filter.mesh = mesh;*/
	}
}
