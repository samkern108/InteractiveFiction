using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public GameObject jukeboxPrefab;
	public List<Jukebox> jukeboxes;

	void Start () 
	{
		jukeboxes = new List<Jukebox> ();
	}

	public void InstantiateJukebox(bool mobile, Vector2 pos, AudioClip clip)
	{
		Jukebox jb = Instantiate (jukeboxPrefab).GetComponent("Jukebox") as Jukebox;
		jukeboxes.Add (jb);
		jb.Instantiate (pos, clip, mobile);
	}
}
