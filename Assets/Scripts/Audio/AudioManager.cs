using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public GameObject jukeboxPrefab;
	public List<Jukebox> jukeboxes;
	public static AudioManager self;

	void Start () 
	{
		self = this;
		jukeboxes = new List<Jukebox> ();
	}

	public Jukebox InstantiateJukeboxFromInfo(JukeboxInfo juke)
	{
		Jukebox jb = Instantiate (jukeboxPrefab).GetComponent("Jukebox") as Jukebox;
		jukeboxes.Add (jb);
		jb.Instantiate (juke, LoadAudio(juke.clip));
		return jb;
	}

	public AudioClip LoadAudio(string musicName)
	{
		return Resources.Load("Sounds/" + musicName, typeof(AudioClip)) as AudioClip;
	}
}
