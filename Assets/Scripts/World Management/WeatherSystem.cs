using UnityEngine;
using System.Collections;

public class WeatherSystem : MonoBehaviour {

	enum Weather 
	{
		thunderstorm,
		lightStorm,
		lightRain,
		sunny,
		cloudy,
		windy,
		snowy,
		heavySnow,
		blizzard
	};

	public float temperature;
	
	void Start () {
		temperature = 0f;
	}

	public void worldTick()
	{
		recalculateTemperature ();
		progressWeather ();
	}

	private void recalculateTemperature()
	{
		temperature = 40.5f;
	}

	private void progressWeather()
	{
	}
}
