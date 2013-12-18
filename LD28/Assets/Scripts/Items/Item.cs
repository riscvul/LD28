using UnityEngine;

public class Item {
	private string _name;
	private int _value;
	private RarityTypes _rarity;
	private int _currentDurability;
	private int _maxDurability;

	public Item() {
		_name = "Unnamed";
		_value = 0;
		_rarity = RarityTypes.Common;
		_maxDurability = 50;
		_currentDurability = _maxDurability;
	}

	public Item(string name, int value, RarityTypes rare, int maxDur, int curDur) {
		_name = name;
		_value = value;
		_rarity = rare;
		_maxDurability = maxDur;
		_currentDurability = curDur;
	}

#region Getters and Setters
	public string Name {
		get{return _name;}
		set{_name = value;}
	}
	public int Value {
		get{return _value;}
		set{_value = value;}
	}
	public RarityTypes Rarity {
		get{return _rarity;}
		set{_rarity = value;}
	}
	public int CurrentDurability {
		get{return _currentDurability;}
		set{_currentDurability = value;}
	}
	public int MaxDurability {
		get{return _maxDurability;}
		set{_maxDurability = value;}
	}
#endregion

}

public enum RarityTypes {
	Common,
	Uncommon,
	Rare
}
