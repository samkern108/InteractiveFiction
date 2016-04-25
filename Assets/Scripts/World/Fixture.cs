using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fixture : MonoBehaviour {

	public FixtureInfo info;
	private List<Bound> bounds;
	public GameObject boundPrefab;
	public Dictionary<string, Jukebox> jukeboxes;

	public void Initialize(FixtureInfo info)
	{
		this.info = info;
		this.transform.localPosition = new Vector3 (info.midpoint.x, info.midpoint.y);

		jukeboxes = new Dictionary<string, Jukebox> ();
		if (info.jukeboxes != null) {
			Jukebox jukebox;
			for (int i = 0; i < info.jukeboxes.Length; i++) {
				jukebox = AudioManager.self.InstantiateJukeboxFromInfo (info.jukeboxes [i]);
				jukeboxes.Add (info.jukeboxes [i].name, jukebox);
			}
		}

		bounds = new List<Bound> ();
		Bound bound;
		for (int i = 0; i < info.bounds.Length; i++) {
			bound = Instantiate (boundPrefab).GetComponent <Bound> ();
			bound.Initialize (info.bounds[i], this);
			bound.transform.parent = transform;
			bound.transform.localPosition = new Vector3 ();
			if (info.bounds [i].audio != null) {
				bound.SetJukebox (jukeboxes[info.bounds[i].audio.jukebox]);
			}
			bounds.Add (bound);
		}
	}

	public int PlayerWithinRadius(Vector2 playerPos, BoundInfo[] bounds, Vector2 midpoint)
	{
		for(int i = 0; i < bounds.Length; i++)
		{
			if(bounds[i].radius >= Mathf.Abs(Vector2.Distance(playerPos, midpoint)))
			{
				return i;
			}
		}
		return -1;
	}

	public Vector2 midpoint()
	{
		return info.midpoint;
	}

	public string name()
	{
		return info.nameFancy;
	}
}
