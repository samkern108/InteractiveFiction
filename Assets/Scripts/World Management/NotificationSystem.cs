using UnityEngine;
using System.Collections;

public class NotificationSystem : MonoBehaviour {

	public enum Notification {worldTick, playerMoved, playerTurned, playerButtonPress, weatherChange};
	public static NotificationSystem instance;

	void Start () {
		instance = this;
	}

	public void SendNotification(Notification n) {
		BroadcastMessage (n.ToString());
	}

	public void SendNotificationWithValue(Notification n, object obj)
	{
		BroadcastMessage (n.ToString(), obj);
	}
}
