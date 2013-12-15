using UnityEngine;
using System.Collections;
using System;				//Access the Enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	public void Awake() {
		_name = string.Empty;
		_level = 0;
		_freeExp = 0;

		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills ();
	}

#region Getters and Setters
	public string Name {
		get { return _name;}
		set {_name = value;}
	}

	public int Level {
		get {return _level;}
		set {_level = value;}
	}

	public uint FreeExp {
		get {return _freeExp;}
		set {_freeExp = value;}
	}
#endregion

	public void AddExp(uint exp) {
		_freeExp =+ exp;
		CalculateLevel();
	}

	//take avg of all of the player's skills and assign that as the player level
	public void CalculateLevel() {
		
	}

	private void SetupPrimaryAttributes() {
		for(int i = 0; i < _primaryAttribute.Length; i++)
		{
			_primaryAttribute[i] = new Attribute();
			_primaryAttribute[i].Name = ((AttributeName)i).ToString();
		}
	}

	private void SetupVitals() {
		for(int i = 0; i < _vital.Length; i++)
		{
			_vital[i] = new Vital();
		}

		SetupVitalModifiers();
	}

	private void SetupSkills() {
		for(int i = 0; i < _skill.Length; i++)
		{
			_skill[i] = new Skill();
		}

		SetupSkillModifiers();
	}

	public Attribute GetPrimaryAttribute(int index) {
		return _primaryAttribute[index];
	}

	public Vital GetVital(int index) {
		return _vital[index];
	}

	public Skill GetSkill(int index) {
		return _skill[index];
	}

	private void SetupVitalModifiers() {
		//Health
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 0.5f));
		//Energy
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1));
		//Mana
		GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1));
	}

	private void SetupSkillModifiers() {
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), 0.33f));
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));

		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 0.33f));

		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));

		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 0.33f));

		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), 0.33f));
		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));

		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), 0.33f));
		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), 0.33f));
	}

	public void StatUpdate() {
		for(int i = 0; i < _vital.Length; i++)
		{
			_vital[i].Update();
		}
		for(int i = 0; i < _skill.Length; i++)
		{
			_skill[i].Update();
		}
	}
}
