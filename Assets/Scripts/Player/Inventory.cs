using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

	private Item[] inventory;
	private int emptySlots;

	public Inventory(int numSlots)
	{
		inventory = new Item[numSlots];
		emptySlots = numSlots;
	}

	public void AddItem(Item i)
	{
		if (emptySlots == 0) {
			Debug.Log ("Inventory full");
		} else {
			for(int j = 0; j < inventory.Length; j++)
			{
				if(inventory[j] != null) {
					inventory[j] = i;
					emptySlots--;
					return;
				}
			}
		}
	}

	public void UseItemInSlot(int i)
	{
		if (inventory.Length > i) {
			Debug.Log ("Note to self... program 'use item' feature later");
		}
	}

	public void DiscardItemInSlot(int i)
	{
		if (inventory.Length > i) {
			inventory[i] = null;
			emptySlots++;
		}
	}

	public bool ContainsItem(Item i)
	{
		foreach (Item j in inventory) {
			if (i.name == j.name) {
				return true;
			}
		}
		return false;
	}
}
