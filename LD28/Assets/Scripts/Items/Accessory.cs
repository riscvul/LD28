using UnityEngine;
using System.Collections;

public class Accessory : BuffItem {
	private AccessorySlot _slot;  //Slot this accessory takes up

	public Accessory() {
		_slot = AccessorySlot.Pocket;
	}

	public Accessory(AccessorySlot slot) {
		_slot = slot;
	}

	public AccessorySlot Slot {
		get{return _slot;}
		set{_slot = value;}
	}
}

public enum AccessorySlot {
	Earings,
	Amulet,
	Ring,
	Pocket
}
