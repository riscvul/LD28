using UnityEngine;
using System.Collections;

public class Mob : BaseCharacter {

	// Use this for initialization
	void Start () {

		Name = "Slug";
		GetPrimaryAttribute((int)AttributeName.Constitution).BaseValue = 100;
		GetVital((int)VitalName.Health).Update();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DisplayHealth() {
		Messenger<int, int>.Broadcast("MobHealthUpdate", 80, 100);
	}
}
