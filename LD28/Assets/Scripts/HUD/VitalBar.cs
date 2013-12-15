using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar;
	private int _maxBarLength;
	private int _curBarLength;
	private GUITexture _display;

	// Use this for initialization
	void Start () {
		//_isPlayerHealthBar = true;

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
		else
			Messenger<int, int>.AddListener("MobHealthUpdate", OnChangeHealthBarSize);

	}

	public void OnDisable() {
		if(_isPlayerHealthBar)
			Messenger<int, int>.RemoveListener("PlayerHealthUpdate", OnChangeHealthBarSize);
		else
			Messenger<int, int>.RemoveListener("MobHealthUpdate", OnChangeHealthBarSize);
	}

	//Calculate size of healthbar based on amount of health the target has left
	public void OnChangeHealthBarSize(int currentHealth, int maxHealth) {
		//Debug.Log("We heard an event : Current Health = " + currentHealth + " MaxHealth = " + maxHealth);
		_curBarLength = (int)((currentHealth / (float)maxHealth) * _maxBarLength);
		_display.pixelInset = new Rect(_display.pixelInset.x,_display.pixelInset.y,_curBarLength,_display.pixelInset.height);
	}

	//Setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b) {
		_isPlayerHealthBar = b;
	}
}
