using UnityEngine;
using System.Collections;

public enum WeatherType 
{
	sunny_mild,
	sunny_med,
	sunny_harsh,
	cloudy_mild,
	cloudy_med,
	cloudy_harsh,
	windy_mild,
	windy_med,
	windy_harsh,
	snowy_mild,
	snowy_med,
	snowy_harsh,
	rainy_mild,
	rainy_med,
	rainy_harsh
};

public class WeatherSystem : MonoBehaviour {

	static Weather weather;
	bool weatherChange = true;

	public static void SetWeather(Weather w)
	{
		weather = w;
	}

	public void WorldTick()
	{
		recalculateTemperature ();
		progressWeather ();
	}

	private void recalculateTemperature()
	{
		weather.temperature = 40.5f;
	}

	private void progressWeather()
	{
		if (weatherChange) {
			UIManager.SetWeather (DataStore.worldConstants.weatherConstants [weather.weatherType]);
			weatherChange = false;
		}
	}
}
