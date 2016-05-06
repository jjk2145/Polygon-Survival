using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	//Which enemy to spawn
	int spawnNumber = 100;

	//Time counter for spawns
	float spawnTimer = 10;
	//Interval at which to spawn them
	float spawnCooldown = 2;

	float roundTimeInterval = 7;

	float round = 1;

	bool inbetweenRound = false;

	//Objects to reference
	public GameObject triangle;
	public GameObject bomber;
	public GameObject ScoreKeeper;
	public GUIText roundText;
	public GUIText prepareText;

	float HPmultiplyer = 1;

	//score from scorekeeper
	int score;
	// Use this for initialization
	void Start () {
		spawnTimer = Time.time + spawnCooldown;
		//prepareText = (GUIText)GameObject.Find("prepare text");
	
	}
	
	// Update is called once per frame
	void Update () {

		score = ScoreKeeper.GetComponent<ScoreKeeper>().score;

		if (score >= 500 && score<749 && round == 1) {
			spawnCooldown = 1.50f;
			round++;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
			spawnTimer += roundTimeInterval;
		}
		if (score >= 750 && score<999 && round == 2) {
			spawnCooldown = 1.25f;
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}
		if (score >= 1000 && score<1999 && round == 3) {
			spawnCooldown = 1f;
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}
		if (score >= 2000 && score<2999 && round == 4) {
			spawnCooldown = .75f;
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}
		if (score >= 3000 && score<3999 && round == 5) {
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}
		if (score >= 4000 && round == 6) {
			//spawnCooldown = .35f;
			HPmultiplyer = 2f;
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}
		if (score >= 5000 && round == 7) {
			//spawnCooldown = .35f;
			HPmultiplyer = 3f;
			round++;
			spawnTimer += roundTimeInterval;
			roundText.text = "Round: " + round;
			prepareText.enabled = true;
		}



		if (Time.time > spawnTimer) {

			spawnNumber = Random.Range (1,101);
			//spawnNumber = 15;

			spawnTimer += spawnCooldown;
			if (spawnNumber >=25 ) {	//75% chance
				//SPAWN TRIANGLE ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				Instantiate(triangle,
					new Vector3(Random.Range(-8,8),9,0),
					Quaternion.identity);
				triangle.GetComponent<TriangleScript> ().hpMultiplyer = HPmultiplyer;
				
			}

			if (spawnNumber <25) {		//25% chance
				//SPAWN BOMBER ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				Instantiate(bomber,
					new Vector3(Random.Range(-14,14),Random.Range(-7,7),0),
					Quaternion.identity);

			}

		}
	}

	public void SpawnerReset()
	{
		spawnNumber = 100;
		spawnTimer = 2;
		spawnCooldown = 2;
	}
}
