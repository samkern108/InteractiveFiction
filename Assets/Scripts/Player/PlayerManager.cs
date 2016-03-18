using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static Inventory playerInventory;
	private int playerInventorySize = 6;
	
	void Start () {
		playerInventory = new Inventory (playerInventorySize);
	}
}
