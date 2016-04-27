using UnityEngine;
using System.Collections;

public struct Clock {
	public int hour;
	public int minute;
	public TimeOfDay timeOfDay;
	public void SetTime(int h, int m){
		hour = h;
		minute = m;
	}
	public string TimeString(){
		string timeString = minute + "";
		string suffix = " AM";
		if (minute < 10) {
			timeString = "0" + timeString;
		}
		if (hour > 12) {
			hour -= 12;
			suffix = " PM";
		}
		return hour + ":" + timeString + suffix;
	}
}

public struct Calendar {
	public Season currentSeason;
	public string dayOfWeek;
	public int year;
	public string seasonString() {
		return currentSeason.ToString ();
	}
}

public enum Season
{
	spring_early,
	spring_med,
	spring_late,
	winter_early,
	winter_med,
	winter_late,
	fall_early,
	fall_med,
	fall_late,
	summer_early,
	summer_med,
	summer_late
}

public enum TimeOfDay
{
	morning_early,
	morning_med,
	afternoon_early,
	afternoon_med,
	evening_early,
	evening_med,
	night_med,
	night_late,
	night_deep
}

public enum Day 
{
	monday,
	tuesday,
	wednesday,
	thursday,
	friday,
	saturday,
	sunday
}

public class WorldClock : MonoBehaviour {
	
									  //s,  m,  h,  d,  m
	byte[] timePerInterval = new byte[] {60, 60, 24, 28, 12};
	float updateAmount = 4f;
	public static float[] dateArray;

	public Season[] seasonOfMonth = new Season[] 
	{
		Season.winter_med, Season.winter_late,
		Season.spring_early, Season.spring_med, Season.spring_late,
		Season.summer_early, Season.summer_med, Season.summer_late,
		Season.fall_early, Season.fall_med, Season.fall_late,
		Season.winter_early
	};

	public TimeOfDay[] timeOfDayForHour = new TimeOfDay[]
	{
		TimeOfDay.night_deep, 
		TimeOfDay.night_deep, 
		TimeOfDay.night_deep, 
		TimeOfDay.morning_early, 
		TimeOfDay.morning_early,
		TimeOfDay.morning_med, 
		TimeOfDay.morning_med, 
		TimeOfDay.morning_med, 
		TimeOfDay.afternoon_early, 
		TimeOfDay.afternoon_early,
		TimeOfDay.afternoon_med, 
		TimeOfDay.afternoon_med, 
		TimeOfDay.afternoon_med, 
		TimeOfDay.afternoon_med,
		TimeOfDay.evening_early, 
		TimeOfDay.evening_early,
		TimeOfDay.evening_early, 
		TimeOfDay.evening_early,
		TimeOfDay.night_med, 
		TimeOfDay.night_med, 
		TimeOfDay.night_med,
		TimeOfDay.night_late, 
		TimeOfDay.night_late,
		TimeOfDay.night_late
	};
	
	private Clock clock;
	public Calendar calendar;

	public static void SetDate(float[] ar)
	{
		dateArray = ar;
	}

	void Start () {
		calendar.currentSeason = Season.winter_med;
	}
	
	void Update () {

		if (dateArray.Length == 0) {
			return;
		}

		dateArray [0] += updateAmount * Time.deltaTime;

		for (int i = 0; i < timePerInterval.Length; i++) {
			if(dateArray[i] >= timePerInterval[i]) {
				dateArray[i] -= timePerInterval[i];
				dateArray[i+1]++;
			}
			else {
				break;
			}
		}

		if (minute () != clock.minute) {
			clock.SetTime(hour (), minute ());
			updateTimeOfDay();
			NotificationSystem.instance.SendNotificationWithValue(Notification.WorldTick, clock);

			if (seasonOfMonth[month ()] != calendar.currentSeason) {
				updateSeason();
				calendar.year = year ();
				NotificationSystem.instance.SendNotificationWithValue(Notification.CalendarTick, calendar);
				DataStore.worldState.clock = dateArray;
			}
		}
	}

	private void updateTimeOfDay()
	{
		clock.timeOfDay = timeOfDayForHour[hour()];
		UIManager.SetClock (DataStore.worldConstants.timeConstants[clock.timeOfDay.ToString()]);
	}

	private void updateSeason()
	{
		calendar.currentSeason = seasonOfMonth[month()];
		UIManager.SetSeason (DataStore.worldConstants.seasonConstants[calendar.currentSeason.ToString()]);
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

	//The following are offset by one in order to prevent Day 0/Month 0/Year 0 of the calendar year
	public int dayOfMonth()
	{
		return (int)dateArray [3] + 1;
	}

	public int dayOfWeek() //I think this works?
	{
		return (int)(dateArray [3] % 7) + 1;
	}

	public int month()
	{
		return (int)dateArray [4] + 1;
	}

	public int year()
	{
		return (int)dateArray [5] + 1 ;
	}
}
