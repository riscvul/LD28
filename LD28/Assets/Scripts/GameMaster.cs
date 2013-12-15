using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject playerCharacter;
	public Camera mainCamera;
	public GameObject gameSettings;

	public float zOffset = -2.5f;
	public float yOffset = 2.5f;
	public float xRotOffset = 22.5f;


	private GameObject _pc;
	private PlayerCharacter _pcScript;

	private Vector3 _playerSpawnPointPos;

	// Use this for initialization
	void Start () {
		_playerSpawnPointPos = new Vector3(300, 6, 400);
		GameObject go = GameObject.Find(GameSettings.PLAYER_SPAWN_POINT);
		if (go == null) 
		{
			Debug.LogWarning("Cannot Find Player Spawn Point!");
			go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);


			go.transform.position = _playerSpawnPointPos;
			Debug.Log("Created Missing Player Spawn Point at : " + _playerSpawnPointPos);
		}

		_pc = Instantiate (playerCharacter, go.transform.position, Quaternion.identity) as GameObject;
		_pc.name = "PC";
		_pc.tag = "Player";
		_pcScript = _pc.GetComponent<PlayerCharacter>();

		mainCamera.transform.position = new Vector3(_pc.transform.position.x,_pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
		mainCamera.transform.Rotate(xRotOffset, 0, 0);

		LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadCharacter() {
		GameObject gs = GameObject.Find("_GameSettings");
		if (gs == null) {
			gs = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			gs.name = "_GameSettings";
		}
		GameSettings gsScript = GameObject.Find ("_GameSettings").GetComponent<GameSettings>();

		gsScript.LoadCharacterData();
	}
}
