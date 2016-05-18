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
	public GameObject thePool;
	thepool PoolScript;
	public GameObject triangle;
	public GameObject bomber;
	public GameObject ScoreKeeper;
	public GUIText roundText;
	public GUIText prepareText;

	turnoffAfter prepareTextTurnOff;

	float HPmultiplyer = 1;
	float speedMultiplyer = 1;

	//score from scorekeeper
	int score;
	// Use this for initialization
	void Start () {

		spawnTimer = Time.time + spawnCooldown;

		prepareTextTurnOff = prepareText.GetComponent<turnoffAfter> ();

		PoolScript = thePool.GetComponent<thepool> ();
		//prepareText = (GUIText)GameObject.Find("prepare text");
	
	}
	
	// Update is called once per frame
	void Update () {

		score = ScoreKeeper.GetComponent<ScoreKeeper>().score;

		if (score >= 500 && score<749 && round == 1) {
			spawnCooldown = 1.50f;
			InBetweenRound ();
		}
		if (score >= 750 && score<999 && round == 2) {
			spawnCooldown = 1.25f;
			InBetweenRound ();
		}
		if (score >= 1000 && score<1999 && round == 3) {
			//spawnCooldown = 1f;
			speedMultiplyer = 1;
			InBetweenRound ();
		}
		if (score >= 2000 && score<2999 && round == 4) {
			spawnCooldown = 1f;
			HPmultiplyer = 2f;
			InBetweenRound ();
		}
		if (score >= 3000 && score<3999 && round == 5) {
			HPmultiplyer = 3f;
			speedMultiplyer =2;
			InBetweenRound ();
		}
		if (score >= 4000 && round == 6) {
			//spawnCooldown = .35f;
			HPmultiplyer = 4f;
			speedMultiplyer = 3;
			InBetweenRound ();
		}
		if (score >= 5000 && round == 7) {
			//spawnCooldown = .35f;
			HPmultiplyer = 5f;
			InBetweenRound ();
		}
		if (score >= 6000 && round == 8) {
			//spawnCooldown = .35f;
			HPmultiplyer = 6f;
			InBetweenRound ();
		}
		if (score >= 7000 && round == 9) {
			//spawnCooldown = .35f;
			HPmultiplyer = 7f;
			InBetweenRound ();
		}
		if (score >= 8000 && round == 10) {
			//spawnCooldown = .35f;
			HPmultiplyer = 8f;
			InBetweenRound ();
		}



		if (Time.time > spawnTimer) {

			spawnNumber = Random.Range (1,101);
			//spawnNumber = 15;

			spawnTimer += spawnCooldown;
			if (spawnNumber >=25 ) {	//75% chance
				//SPAWN TRIANGLE ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				/*Instantiate(triangle,
					new Vector3(Random.Range(-8,8),9,0),
					Quaternion.identity);
				triangle.GetComponent<TriangleScript> ().hpMultiplyer = HPmultiplyer;*/
				GameObject triangleClone = PoolScript.CheckForInactiveTriangle();
				if(triangleClone == null)
				{
					triangleClone = (GameObject)Instantiate(triangle,
					            new Vector3(Random.Range(-8,8),9,0),
					            Quaternion.identity);
					triangleClone.GetComponent<TriangleScript> ().hpMultiplyer = HPmultiplyer;
					triangleClone.GetComponent<TriangleScript> ().speed += speedMultiplyer;
					PoolScript.triangleEnemyList.Add(triangleClone);
				}
				else{
					
					//triangleClone.transform.position = new Vector3(Random.Range(-8,8),9,0);
					triangleClone.GetComponent<TriangleScript> ().hpMultiplyer = HPmultiplyer;
					triangleClone.GetComponent<TriangleScript> ().speed += speedMultiplyer;
					triangleClone.SetActive(true);

				}
				
			}

			if (spawnNumber <25) {		//25% chance
				//SPAWN BOMBER ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);

				GameObject bomberClone = PoolScript.CheckForInactiveBomber();

				if(bomberClone == null)
				{
					Instantiate(bomber,
						new Vector3(Random.Range(-14,14),Random.Range(-7,7),0),
						Quaternion.identity);

					PoolScript.bomberEnemyList.Add(bomberClone);
				}
				else{
					bomberClone.transform.position = new Vector3(Random.Range(-14,14),Random.Range(-7,7),0);
					bomberClone.SetActive(true);
				}

			}

		}
	}

	public void SpawnerReset()
	{
		spawnNumber = 100;
		spawnTimer = 2;
		spawnCooldown = 2;
	}

	public void InBetweenRound ()
	{
		round++;
		roundText.text = "Round: " + round;
		prepareText.text = "Round complete \nprepare for next round...";
		prepareTextTurnOff.timeTurnedOn = Time.time;
		spawnTimer += roundTimeInterval;
	}
}
