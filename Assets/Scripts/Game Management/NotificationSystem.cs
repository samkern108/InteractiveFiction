using UnityEngine;
using System.Collections;

public enum Notification {ForceUpdate, CalendarTick, WorldTick, PlayerMoved, PlayerButtonPress, WeatherChange, ToggleVisuals};

public class NotificationSystem : MonoBehaviour {
	
	public static NotificationSystem instance;

	void Start () {
		instance = this;
	}

	public void SendNotification(Notification n) {
		Debug.Log ("Sending notification: " + n);
		BroadcastMessage (n.ToString());
	}

	public void SendNotificationWithInteger(Notification n, int i)
	{
		Debug.Log ("Sending notification: " + n);
		BroadcastMessage (n.ToString(), i);
	}

	public void SendNotificationWithValue(Notification n, object obj)
	{
		Debug.Log ("Sending notification: " + n);
		BroadcastMessage (n.ToString(), obj);
	}
}
