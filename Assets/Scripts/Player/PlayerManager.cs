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
	}

	public void TiredChanged(float value)
	{
		DataStore.SetConditionValue ("tired", value);
	}

	public void MoistureChanged(float value)
	{
		DataStore.SetConditionValue ("moisture", value);
	}

	public void WarmthChanged(float value)
	{
		DataStore.SetConditionValue ("warmth", value);
	}
}
