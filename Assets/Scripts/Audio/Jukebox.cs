using UnityEngine;
using System.Collections;

public class Jukebox : MonoBehaviour {
	
	public Vector2 position = new Vector2();
	public AudioClip clip;
	public AudioSource source;
	public bool mobile = false;

	void Start() {
		source = this.GetComponent ("AudioSource") as AudioSource;
	}

	public void Instantiate(Vector2 position, AudioClip clip, bool mobile) {
		this.position = position;
		this.clip = clip;
		this.source.Play ();
		this.mobile = mobile;
	}
}
