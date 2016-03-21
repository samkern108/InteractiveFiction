﻿using UnityEngine;
using System.Collections;

public enum Notification {ForceUpdate, CalendarTick, WorldTick, PlayerMoved, PlayerButtonPress, WeatherChange, ToggleVisuals};

public class NotificationSystem : MonoBehaviour {
	
	public static NotificationSystem instance;

	void Start () {
		instance = this;
	}

	public void SendNotification(Notification n) {
		BroadcastMessage (n.ToString());
	}

	public void SendNotificationWithInteger(Notification n, int i)
	{
		BroadcastMessage (n.ToString(), i);
	}

	public void SendNotificationWithValue(Notification n, object obj)
	{
		BroadcastMessage (n.ToString(), obj);
	}
}
