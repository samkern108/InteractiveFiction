using UnityEngine;
using System.Collections;

public class WeatherParticles : MonoBehaviour {

	public ParticleSystem _snow;
	public ParticleSystem _mystical;
	public ParticleSystem _embers;
	public ParticleSystem _fog;
	public ParticleSystem _lights;
	public ParticleSystem _sparks;
	public ParticleSystem _rain;
	public ParticleSystem _sand;
	public ParticleSystem _leaves;
	public ParticleSystem[] systems;

	void Start()
	{
		systems = new ParticleSystem[] { _snow, _mystical, _embers, _fog, _lights, _sparks, _rain, _sand, _leaves };
		DeactivateAllWeather();
	}

	//figure out how to do particle size
	public void PlayRainEffect(float intensity, float windFactor, int windAngle)
	{
	}

	private int snowMaxParticles = 10000;
	private int snowEmission = 20;
	private int ySnowSpeed = 20;
	private int xSnowSpeed = 3;

	public void PlaySnowEffect(float intensity, float maxParticleSize, float ySpeed, float windFactor, float windAngle)
	{
		_snow.maxParticles = (int)(intensity * snowMaxParticles);

		_snow.startSize = maxParticleSize;
		var emission = _snow.emission;

		ParticleSystem.MinMaxCurve emcurve = new ParticleSystem.MinMaxCurve ();
		emcurve.constantMax = intensity * snowEmission;
		emission.rate = emcurve;

		Vector2 windDirs = new Vector2 (Mathf.Sin(Mathf.Deg2Rad * windAngle) * windFactor, Mathf.Cos(Mathf.Deg2Rad * windAngle) * windFactor);

		var vOL = _snow.velocityOverLifetime;

		ParticleSystem.MinMaxCurve mmcx = new ParticleSystem.MinMaxCurve ();
		mmcx.constantMin = -3;
		mmcx.constantMax = 3;
		mmcx.mode = ParticleSystemCurveMode.TwoConstants;

		ParticleSystem.MinMaxCurve mmcy = new ParticleSystem.MinMaxCurve ();
		mmcy.constantMin = -10;
		mmcy.constantMax = -2;
		mmcy.mode = ParticleSystemCurveMode.TwoConstants;

		vOL.x = mmcx;
		vOL.y = mmcy;

		_snow.Play ();
	}

	private void DeactivateAllWeather()
	{
		for (int i = 0; i < systems.Length; i++) {
			if (systems [i] != null && systems [i].isPlaying) {
				systems [i].Stop ();
			}
		}
	}
}
