using UnityEngine;
using System.Collections;

public class Weapon : BuffItem {
	private int _maxDamage;
	private float _dmgVariance;
	private float _maxRange;
	private DamageTypes _dmgType;

	public Weapon() {
		_maxDamage = 0;
		_dmgVariance = 0;
		_maxRange = 0;
		_dmgType = DamageTypes.Bashing;
	}

	public Weapon(int mDmg, float dmgVar, float range, DamageTypes dt) {
		_maxDamage = mDmg;
		_dmgVariance = dmgVar;
		_maxRange = range;
		_dmgType = dt;
	}

#region Getters and Setters
	public int MaxDamage {
		get{return _maxDamage;}
		set{_maxDamage = value;}
	}
	public float DmgVariance {
		get{return _dmgVariance;}
		set{_dmgVariance = value;}
	}
	public float MaxRange {
		get{return _maxRange;}
		set{_maxRange = value;}
	}
	public DamageTypes DamageType {
		get{return _dmgType;}
		set{_dmgType = value;}
	}
#endregion
	
}

public enum DamageTypes {
	Bashing,
	Piercing,
	Slashing,
	Fire,
	Lightning,
	Poison,
	Acid
}
