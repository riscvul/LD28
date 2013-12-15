using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour {
	private PlayerCharacter _player;
#region Display Consts
	private const int STARTING_POINTS = 350;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private const int OFFSET      = 5;
	private const int LINE_HEIGHT = 20;
	private const int STAT_LABEL_WIDTH = 100;
	private const int BASE_VALUE_LABEL_WIDTH = 30;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;
#endregion
	private int statStartingPos = 40;
	private int pointsLeft;

	public GUIStyle myStyle;
	public GUISkin  mySkin;

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		GameObject pc = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		pc.name = "PC"; 

		_player = pc.GetComponent<PlayerCharacter>();
		_player.Awake();

		pointsLeft = STARTING_POINTS;

		for(int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			_player.GetPrimaryAttribute(i).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
		}
		_player.StatUpdate();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI () {
		GUI.skin = mySkin;
		DisplayName();
		DisplayPointsLeft();
		DisplayAttributes();
		DisplayVitals();
		DisplaySkills();
		if(_player.Name != "" && pointsLeft == 0)
			DisplayCreateButton();
		else
			DisplayCreateLabel();
	}

	private void DisplayName() {
		GUI.Label(new Rect(10, 10, 50, 25), "Name:");
		_player.Name = GUI.TextField(new Rect(65, 10, 100, 25), _player.Name);
	}

	private void DisplayPointsLeft() {
		GUI.Label (new Rect(250, 10, 100, 25), "Points Left : " + pointsLeft);
	}

	private void DisplayAttributes() {
		for(int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
			GUI.Label(new Rect(OFFSET, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName)i).ToString(), myStyle);
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, statStartingPos + (i * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _player.GetPrimaryAttribute(i).AdjustedBaseValue.ToString(), myStyle);
			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-")) {
				if(_player.GetPrimaryAttribute(i).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE) {
					_player.GetPrimaryAttribute(i).BaseValue--;
					pointsLeft++;
					_player.StatUpdate();
				}
			}
			if(GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH, statStartingPos + (i * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+")) {
				if(pointsLeft > 0) {
					_player.GetPrimaryAttribute(i).BaseValue++;
					pointsLeft--;
					_player.StatUpdate();
				}
			}
		}
	}

	private void DisplayVitals() {
		for(int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			GUI.Label(new Rect(OFFSET, statStartingPos + ((i + 7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)i).ToString() );
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH, statStartingPos + ((i + 7) * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _player.GetVital(i).AdjustedBaseValue.ToString()); 
		}
	}

	private void DisplaySkills() {
		for(int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2, statStartingPos + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)i).ToString() );
			GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH + BASE_VALUE_LABEL_WIDTH + BUTTON_WIDTH * 2 + OFFSET * 2 + STAT_LABEL_WIDTH, statStartingPos + (i * LINE_HEIGHT), BASE_VALUE_LABEL_WIDTH, LINE_HEIGHT), _player.GetSkill(i).AdjustedBaseValue.ToString()); 
		}
	}

	private void DisplayCreateButton() {
		if(GUI.Button(new Rect(Screen.width / 2 - 120, statStartingPos + (10 * LINE_HEIGHT), 120, LINE_HEIGHT),"Create Character")) {
			GameObject gs = GameObject.Find("_GameSettings");
			GameSettings gsScript = gs.GetComponent<GameSettings>();

			//Update current Vital values before saving.
			UpdateCurrentVitalValues();
			gsScript.SaveCharacterData();

			Application.LoadLevel("Level1");
		}
	}

	private void DisplayCreateLabel() {
		GUI.Button(new Rect(Screen.width / 2 - 120, statStartingPos + (10 * LINE_HEIGHT), 120, LINE_HEIGHT),"Finish First");
	}

	private void UpdateCurrentVitalValues() {
		for(int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
			_player.GetVital(i).CurValue = _player.GetVital(i).AdjustedBaseValue;
		}
	}
}
