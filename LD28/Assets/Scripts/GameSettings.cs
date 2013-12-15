﻿using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {
	public const string PLAYER_SPAWN_POINT = "Player Spawn Point";
	public void Awake() {
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveCharacterData() {
		GameObject pc = GameObject.Find("PC");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

		//PlayerPrefs.DeleteAll();

		PlayerPrefs.SetString("Player Name", pcClass.Name);
		for(int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			PlayerPrefs.SetInt(((AttributeName)i).ToString() + " - Base Value",pcClass.GetPrimaryAttribute(i).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)i).ToString() + " - Exp To Level",pcClass.GetPrimaryAttribute(i).ExpToLevel);
		}

		PlayerPrefs.SetString("Player Name", pcClass.Name);
		for(int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Base Value",pcClass.GetVital(i).BaseValue);
			PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Exp To Level",pcClass.GetVital(i).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Current Value",pcClass.GetVital(i).CurValue);
			//PlayerPrefs.SetString(((VitalName)i).ToString() + " - Modifying Attributes",pcClass.GetVital(i).GetModifyingAttributeString());

			
		}

		PlayerPrefs.SetString("Player Name", pcClass.Name);
		for(int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Base Value",pcClass.GetSkill(i).BaseValue);
			PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Exp To Level",pcClass.GetSkill(i).ExpToLevel);
			//PlayerPrefs.SetString(((SkillName)i).ToString() + " - Modifying Attributes", pcClass.GetSkill(i).GetModifyingAttributeString());
			
		}
	}

	public void LoadCharacterData() {
		GameObject pc = GameObject.Find("PC");
		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

		pcClass.Name = PlayerPrefs.GetString("Player Name", "Prisoner");

		for(int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			pcClass.GetPrimaryAttribute(i).BaseValue = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Base Value",0);
			pcClass.GetPrimaryAttribute(i).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Exp To Level",Attribute.STARTING_EXP_COST);
		}
		
		PlayerPrefs.SetString("Player Name", pcClass.Name);
		for(int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			pcClass.GetVital(i).BaseValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Base Value",0);
			pcClass.GetVital(i).ExpToLevel = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Exp To Level",Vital.STARTING_EXP_COST);

			pcClass.GetVital(i).Update();

			pcClass.GetVital(i).CurValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Current Value",1);
		}
		
		PlayerPrefs.SetString("Player Name", pcClass.Name);
		for(int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			pcClass.GetSkill(i).BaseValue = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Base Value",0);
			pcClass.GetSkill(i).ExpToLevel = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Exp To Level",Skill.STARTING_EXP_COST);

			pcClass.GetSkill(i).Update();


		}
	}
}
