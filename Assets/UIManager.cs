using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static Text prompt;
	public static Text clock;
	public static Text weather;
	public static Text season;

	public void Start()
	{
		prompt = GameObject.Find ("_Prompt").GetComponent<Text>();
		clock = GameObject.Find ("_Clock").GetComponent<Text>();
		weather = GameObject.Find ("_Weather").GetComponent<Text>();
		season = GameObject.Find ("_Season").GetComponent<Text>();
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
}
