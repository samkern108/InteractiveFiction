using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static Inventory playerInventory;
	private int playerInventorySize = 6;
	
	void Start () {
		playerInventory = new Inventory (playerInventorySize);
	}

	public void HungerChanged(float value)
	{
		DataStore.SetConditionValue ("hunger", value);
		NotificationSystem.instance.SendNotification (Notification.ForceUpdate);
	}

	public void TiredChanged(float value)
	{
		DataStore.SetConditionValue ("tired", value);
		NotificationSystem.instance.SendNotification (Notification.ForceUpdate);

	}

	public void MoistureChanged(float value)
	{
		DataStore.SetConditionValue ("moisture", value);
		NotificationSystem.instance.SendNotification (Notification.ForceUpdate);

	}

	public void WarmthChanged(float value)
	{
		DataStore.SetConditionValue ("warmth", value);
		NotificationSystem.instance.SendNotification (Notification.ForceUpdate);
	}
}
