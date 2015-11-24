using UnityEngine;
using System.Collections;

public class WorldClock : MonoBehaviour {
	
									  //second, minute, hour, day, month, year
	int[] timePerInterval = new int[] {60, 60, 24, 30, 12};
	float updateAmount = .25f;
	float sendUpdateCycles = 10f;
	public float[] dateArray;
	public WorldClock instance;

	public enum Season
	{
		earlySpring, spring, lateSpring,
		earlyWinter, winter, lateWinter,
		earlyFall, fall, lateFall,
		earlySummer, summer, lateSummer
	}

	public string[] day = new string[]
	{
		"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
	};

	public Season[] seasonOfMonth = new Season[] 
	{
		Season.winter, Season.lateWinter,
		Season.earlySpring, Season.spring, Season.lateSpring,
		Season.earlySummer, Season.summer, Season.lateSummer,
		Season.earlyFall, Season.fall, Season.lateFall,
		Season.earlyWinter
	};

	public Season currentSeason;

	public enum TimeOfDay
	{
		earlyMorning, morning, earlyAfternoon,
		afternoon, earlyEvening, evening,
		night, lateNight, deepNight
	}

	public TimeOfDay[] timeOfDayForHour = new TimeOfDay[]
	{
		TimeOfDay.lateNight,
		TimeOfDay.deepNight, TimeOfDay.deepNight, TimeOfDay.deepNight,
		TimeOfDay.earlyMorning, TimeOfDay.earlyMorning,
		TimeOfDay.morning, TimeOfDay.morning, TimeOfDay.morning,
		TimeOfDay.earlyAfternoon, TimeOfDay.earlyAfternoon,
		TimeOfDay.afternoon, TimeOfDay.afternoon, TimeOfDay.afternoon, TimeOfDay.afternoon,
		TimeOfDay.earlyEvening, TimeOfDay.earlyEvening,
		TimeOfDay.evening, TimeOfDay.evening,
		TimeOfDay.night, TimeOfDay.night, TimeOfDay.night,
		TimeOfDay.lateNight
	};

	public TimeOfDay currentTimeOfDay;

	void Start () {
		dateArray = new float[] {0,0,0,0,0,1};
		currentSeason = Season.winter;
		//eventually read from file.
	}

	//make ABSOLUTELY CERTAIN that the clock is stable before releasing
	void FixedUpdate () {
		dateArray [0] += updateAmount;
		if (dateArray [0] % sendUpdateCycles == 0) {
			NotificationSystem.instance.SendNotificationWithValue(NotificationSystem.Notification.worldTick, currentTimeOfDay); //what should we send here?
			updateTimeOfDay();
			updateSeason();
		}
		for (int i = 0; i < timePerInterval.Length; i++) {
			if(dateArray[i] >= timePerInterval[i]) {
				dateArray[i] -= timePerInterval[i];
				dateArray[i+1]++;
			}
			else {
				break;
			}
		}
//		Debug.Log (dateArray[0] + " , " + dateArray[1] + " , " + dateArray[2] + " , " + dateArray[3] + " , " + dateArray[4] + " , " + dateArray[5]);
	}

	private void updateTimeOfDay()
	{
		currentTimeOfDay = timeOfDayForHour[hour()];
	}

	private void updateSeason()
	{
		currentSeason = seasonOfMonth[month()];
	}

	public float seconds()
	{
		return dateArray[0];
	}

	public int minute()
	{
		return (int)dateArray [1];
	}

	public int hour()
	{
		return (int)dateArray [2];
	}

	public int dayOfMonth()
	{
		return (int)dateArray [3];
	}

	public int dayOfWeek() //I think this works?
	{
		return (int)(dateArray [3] % 7);
	}

	public int month()
	{
		return (int)dateArray [4];
	}

	public int year()
	{
		return (int)dateArray [5];
	}
}
