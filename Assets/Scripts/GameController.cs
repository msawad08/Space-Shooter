using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int hazardCount;
	public float waitTime,interval;
	public GameObject hazard;
	public Vector3 spawnPos;
	public Text scoreText;
	public Text gameoverText;
	public Text restartText;
	private int score;
	public int scoreValue;
	private bool gameOver, restart;
	private bool started;
	public PlayerController playerController;

	// Use this for initialization
	void Start () {
		
		score = 0;
		scoreText.text = "score :" + score;
		gameoverText.text = "Tap to start the game";
		restartText.text = "";
		gameOver = false;
		restart = false;
		started = false;
		spawnPos.x = (Camera.main.aspect * Camera.main.orthographicSize);
	}

	void Update(){
		if (Input.GetButton ("Cancel"))
			Application.Quit();
		if (Input.GetMouseButtonDown(0))
			Fired ();
	}

	// Update is called once per frame
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (waitTime);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 pos=new Vector3(Random.Range(-spawnPos.x, spawnPos.x), spawnPos.y,spawnPos.z);
				Instantiate (hazard, pos,Quaternion.identity);
				yield return new WaitForSeconds (interval);

			}
			if (gameOver) {
				restartText.text = "Touch to Restart";
				restart = true;
				break;
			}
			yield return new WaitForSeconds (waitTime);

		}

	}
	public void AddScore(){
		score += scoreValue;
		scoreText.text = "score :" + score;

	}

	public void GameOver(){
		gameoverText.text = "Game Over";
		gameOver = true;
	}
	public void Fired(){
		if (restart) {
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else if (!started) {
			started = true;
			gameoverText.text = "";
			StartCoroutine (SpawnWaves ());

		}	
	}
}