using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {
	public enum State {
		Idle,
		Initialize,
		Setup,
		SpawnMob
	}
	public GameObject[] mobPrefabs;  //an array to hold all of the mob prefabs we want to spawn
	public GameObject[] spawnPoints; //all of the current spawnpoint objects

	public State state; //Current State

	void Awake() {
		state = State.Initialize;
	}

	// Use this for initialization
	IEnumerator Start () {
		while(true) {
			switch(state) {
			case State.Idle:
				break;
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnMob:
				SpawnMob();
				break;
			default:
				break;
			}
			yield return 0;
		}
	}

	private void Initialize() {
		Debug.Log("In the Initialize State");
		if(!CheckForMobPrefabs())
			return;
		if(!CheckForSpawnPoints())
			return;
		state = State.Setup;
	}

	private void Setup() {
		Debug.Log("In the Setup State");
		state = State.SpawnMob;
	}

	private void SpawnMob() {
		Debug.Log("In the SpawnMob State");

		GameObject[] gos = AvailableSpawnPoints();

		for(int i = 0; i < gos.Length; i++)
		{
			GameObject go = Instantiate(mobPrefabs[Random.Range(0,mobPrefabs.Length)], gos[i].transform.position, Quaternion.identity) as GameObject;
			go.transform.parent = gos[i].transform;
		}

		state = State.Idle;
	}

	//Check for at least one mob type to spawn
	private bool CheckForMobPrefabs() {
		if(mobPrefabs.Length > 0)
			return true;
		else
			return false;
	}

	//Check for at least one mob spawn point
	private bool CheckForSpawnPoints() {
		if(spawnPoints.Length > 0)
			return true;
		else
			return false;
	}

	//Generate a list of spawnpoints without any mobs childed to them
	private GameObject[] AvailableSpawnPoints() {
		List<GameObject> gos = new List<GameObject>();
		for(int i = 0; i < spawnPoints.Length; i++) {
			if(spawnPoints[i].transform.childCount == 0) {
				gos.Add(spawnPoints[i]);
			}
		}
		return gos.ToArray();
	}
	

}
