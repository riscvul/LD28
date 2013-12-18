using UnityEngine;

public class Consumable : BuffItem {
	private Vital[] _vitals;  //List of vitals affected by this consumable
	private int[] _effectAmount;
	private float _buffTime;

	public Consumable() {
		Reset();
	}

	public Consumable(Vital[] v, int[] a, float buffTime) {
		_vitals = v;
		_effectAmount = a;
		_buffTime = buffTime;
	}

	public void Reset() {
		_buffTime = 0;
		for(int i = 0; i < _vitals.Length; i++)
		{
			_vitals[i] = new Vital();
			_effectAmount[i] = 0;
		}
	}

	public int VitalCount() {
		return _vitals.Length;
	}

	public Vital VitalAtIndex(int index) {
		if(index < _vitals.Length && index > -1)
			return _vitals[index];
		else
			return new Vital();
	}

	public int EffectAtIndex(int index) {
		if(index < _effectAmount.Length && index > -1)
			return _effectAmount[index];
		else
			return 0;
	}

	public void SetVitalAt(int index, Vital v) {
		if(index < _vitals.Length && index > -1)
			_vitals[index] = v;
	}

	public void SetEffectAt(int index, int effect) {
		if(index < _effectAmount.Length && index > -1)
			_effectAmount[index] = effect;
	}

	public void SetVitalAndEffectAt(int index, Vital v, int effect) {
		SetVitalAt(index, v);
		SetEffectAt(index, effect);
	}
	
	public float BuffTime {
		get{return _buffTime;}
		set{_buffTime = value;}
	}
}
