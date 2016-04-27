using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputWrapper: MonoBehaviour {

	public GameObject menu;
	public GameObject inventory;
	//public Text clockText;
	//public Text seasonText;
	//public Text weatherText;

	void Update () {
		if (Input.GetKeyDown("escape")) {
			menu.SetActive(!menu.activeInHierarchy);
		}
		if (Input.GetKeyDown ("space")) {
			inventory.SetActive(!inventory.activeInHierarchy);
		}
	}

	/*public void WorldTick(Clock time) {
		clockText.text = time + "";
	}

	public void CalendarTick(Calendar cal) {
		seasonText.text = DataStore.worldConstants.seasonConstants[cal.seasonString()];
	}

	public void WeatherChange(Weather weather) {
		weatherText.text = DataStore.worldConstants.seasonConstants[weather.weatherType];
	}*/
}
