using UnityEngine;
using System.Collections;

/// <summary>
/// BaseStat.cs
/// Devin Nelson
/// </summary>
public class BaseStat {
	public const int STARTING_EXP_COST = 100;

	private int _baseValue;			//Base value of stat
	private int _buffValue;			//Amount of buff to this stat
	private int _expToLevel;		//Experience needed to get next point of base value
	private float _levelModifier;	//Modifier applied to exp needed to raise the stat

	public BaseStat() {
		_baseValue     = 0;
		_buffValue     = 0;
		_levelModifier = 1.1f;
		_expToLevel    = STARTING_EXP_COST;
	}

#region Setters and Getters

	//Setters and Getters
	public int BaseValue {
		get{ return _baseValue;}
		set{ _baseValue = value;}
	}

	public int BuffValue {
		get{ return _buffValue;}
		set{ _baseValue = value;}
	}

	public int ExpToLevel {
		get{ return _expToLevel;}
		set{ _expToLevel = value;}
	}

	public float LevelModifier {
		get{ return _levelModifier;}
		set{ _levelModifier = value;}
	}

#endregion

	private int CalculateExpToLevel() {
		return (int)(_expToLevel * _levelModifier);
	}

	public void LevelUp() {
		_expToLevel = CalculateExpToLevel();
		_baseValue++;
	}

	public int AdjustedBaseValue {
		get { return _baseValue + _buffValue;}
	}
}
