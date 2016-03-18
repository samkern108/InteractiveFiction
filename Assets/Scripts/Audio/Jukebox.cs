using UnityEngine;
using System.Collections;

public class Jukebox : MonoBehaviour {
	
	public AudioClip clip;
	public AudioSource source;

	JukeboxInfo jukeinfo;

	public void Instantiate(JukeboxInfo info, AudioClip clip) {
		source = this.GetComponent ("AudioSource") as AudioSource;
		this.jukeinfo = info;
		this.clip = clip;
		this.source.clip = clip;
	}

	public void Play()
	{
		if(!source.isPlaying)
			source.Play ();
	}

	public void StopPlaying()
	{
		if(source.isPlaying)
			source.Stop ();
	}

	public void AdjustVolumeForDistance(Vector2 sourceLocation, Vector2 position, float maxDist)
	{
		float volume = Mathf.Clamp(Vector2.Distance(sourceLocation, position), 0, maxDist);
		source.volume = volume.Map (0, maxDist, 1.0f, 0.0f);
	}
}
