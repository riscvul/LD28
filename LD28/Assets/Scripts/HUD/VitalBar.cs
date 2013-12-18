using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar;
	private int _maxBarLength;
	private int _curBarLength;
	private GUITexture _display;

	void Awake() {
		_display = gameObject.GetComponent<GUITexture>();
	}

	// Use this for initialization
	void Start () {
		_display = gameObject.GetComponent<GUITexture>();

		_maxBarLength = (int)_display.pixelInset.width;
		OnEnable();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable() {
		if(_isPlayerHealthBar)
			Messenger<int, int>.AddListener("PlayerHealthUpdate", OnChangeHealthBarSize);
		else {
			ToggleDisplay(false);
			Messenger<int, int>.AddListener("MobHealthUpdate", OnChangeHealthBarSize);
			Messenger<bool>.AddListener("ShowMobVitalBars", ToggleDisplay);
		}
	}

	public void OnDisable() {
		if(_isPlayerHealthBar)
			Messenger<int, int>.RemoveListener("PlayerHealthUpdate", OnChangeHealthBarSize);
		else {
			Messenger<int, int>.RemoveListener("MobHealthUpdate", OnChangeHealthBarSize);
			Messenger<bool>.RemoveListener("ShowMobVitalBars", ToggleDisplay);
		}
	}

	//Calculate size of healthbar based on amount of health the target has left
	public void OnChangeHealthBarSize(int currentHealth, int maxHealth) {
		//Debug.Log("We heard an event : Current Health = " + currentHealth + " MaxHealth = " + maxHealth);
		_curBarLength = (int)((currentHealth / (float)maxHealth) * _maxBarLength);
		_display.pixelInset = CalculatePosition(); //new Rect(_display.pixelInset.x,_display.pixelInset.y,_curBarLength,_display.pixelInset.height);
	}

	//Setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b) {
		_isPlayerHealthBar = b;
	}

	private Rect CalculatePosition() {
		float yPos = 0;
		if(!_isPlayerHealthBar)
		{
			float xPos = (_maxBarLength - _curBarLength) - (_maxBarLength / 4 + 10);
			return new Rect(xPos,_display.pixelInset.y,_curBarLength,_display.pixelInset.height);
		}
		return new Rect(_display.pixelInset.x,_display.pixelInset.y,_curBarLength,_display.pixelInset.height);
	}

	private void ToggleDisplay(bool show) {
		_display.enabled = show;
	}
}
