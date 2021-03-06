﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coolDown;
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		if (attackTimer <= 0) {
			attackTimer = coolDown;
			Attack();
		}
	}
	
	private void Attack() {
		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector2 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		
		Debug.Log(direction);
		
		if (distance < 2.5f && direction > 0) {
			PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
			eh.AdjustCurrentHealth(-10);
		}
	}
}
