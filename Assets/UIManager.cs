using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static Text prompt;
	public static Text clock;
	public static Text weather;
	public static Text season;

	public static Slider hunger;
	public static Slider moisture;
	public static Slider warmth;
	public static Slider tired;

	public void Start()
	{
		prompt = GameObject.Find ("_Prompt").GetComponent<Text>();
		clock = GameObject.Find ("_Clock").GetComponent<Text>();
		weather = GameObject.Find ("_Weather").GetComponent<Text>();
		season = GameObject.Find ("_Season").GetComponent<Text>();

		hunger = GameObject.Find ("_Hunger").GetComponent <Slider>();
		moisture = GameObject.Find ("_Moisture").GetComponent <Slider>();
		warmth = GameObject.Find ("_Warmth").GetComponent <Slider>();
		tired = GameObject.Find ("_Tired").GetComponent <Slider>();
	}

	public static void SetPrompt(string text)
	{
		prompt.text = text;
	}

	public static void SetSeason(string text)
	{
		season.text = text;
	}

	public static void SetWeather(string text)
	{
		weather.text = text;
	}

	public static void SetClock(string text)
	{
		clock.text = text;
	}

	public static void UpdateSliders()
	{
		hunger.value = DataStore.GetConditionValue("hunger");
		warmth.value = DataStore.GetConditionValue("warmth");
		moisture.value = DataStore.GetConditionValue("moisture");
		tired.value = DataStore.GetConditionValue("tired");
	}

	public void WorldTick()
	{
		UpdateSliders ();
	}
}
