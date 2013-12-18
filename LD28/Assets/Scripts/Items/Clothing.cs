﻿using UnityEngine;
using System.Collections;

public class Clothing : BuffItem {
	private ArmorSlot _slot;

	public Clothing() {
		_slot = ArmorSlot.Head;
	}

	public Clothing(ArmorSlot slot) {
		_slot = slot;
	}

	public ArmorSlot Slot {
		get{ return _slot;}
		set{_slot = value;}
	}

}

public enum ArmorSlot {
	Head,
	Shoulder,
	Chest,
	Legs,
	Hands,
	Feet,
	Cape
}
