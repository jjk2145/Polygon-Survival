using UnityEngine;
using System.Collections;

public class BomberScript : MonoBehaviour {
	public GameObject bullet;
	Vector3 bulDirection = new Vector3(.4f,.4f,0);
	bool canIShoot = true;



	float TimeSpawned;
	float shootTimer;


	public int scoreValue;
	private ScoreKeeper scoreKeeper;
	float enemyHealth = 3;

	public GameObject gameManager;
	public DropPowerup dropPowerupScript;


	// Use this for initialization
	void Start () {
		TimeSpawned = Time.time;
		shootTimer = Time.time - 3f;

		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper");
		if (scoreKeeperObject != null) {
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper> ();
		}
		else{
			//Debug.Log ("Can't find 'ScoreKeeper' script");
		}

		dropPowerupScript = gameManager.GetComponent <DropPowerup> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (shootTimer + 4f < Time.time) {

					GameObject Clone = (GameObject)Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
					
					bulDirection = new Vector3(-.4f,-.4f,0);
					
					//print ("neg neg" + bulDirection);
					
					Clone.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
					

		
			Clone = (GameObject)Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(.4f,.4f,0);
					//print ("pos pos" + bulDirection);

					Clone.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
	

		
			Clone = (GameObject)Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(-.4f,.4f,0);
					//print ("neg pos"+bulDirection);

					Clone.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;


		
			Clone = (GameObject)Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(.4f,-.4f,0);
					//print ("pos neg" + bulDirection);

					Clone.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;

						shootTimer = Time.time;
					
		}

		//delete here
		if (enemyHealth <= 0) { 
			dropPowerupScript.location = transform.position;
			dropPowerupScript.RNG ();
			Destroy (gameObject);
		}

	}



	void OnCollisionEnter2D(Collision2D coll){						// when hit by playerBullet
		if (coll.gameObject.tag == "PlayerBullet") {
			onHit ();
		}
		if (TimeSpawned + 2f < Time.time) {
			if (coll.gameObject.tag == "Player") {
				enemyHealth = 0;
			}
		}
	}

	void onHit ()
	{
		if (enemyHealth <= 1) {
			scoreKeeper.AddScore ();

		}
		enemyHealth--;

		if (enemyHealth == 2) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 126, 21, 255);
		}

		if (enemyHealth == 1) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color32 (255, 145, 63, 255);
		}
	}
}
