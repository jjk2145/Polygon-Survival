using UnityEngine;
using System.Collections;

public class DropPowerup : MonoBehaviour {

	float dropCheck = -1;
	float powerupNumber = 0;
	public float percentChanceForPowerup = 50;
	public GameObject HPUp;
	public GameObject tripleShot;
	public GameObject rapidFire;

	public Vector3 location;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dropCheck != 0 && dropCheck > 100-percentChanceForPowerup) {
			spawnPowerup ();
			dropCheck = -1;
		}
	}

	void checkForSpawn()
	{
		print ("Checking to see if you got a powerup drop.....");
		if (dropCheck != 0 && dropCheck > 100-percentChanceForPowerup) {
			spawnPowerup ();

		}
		dropCheck = 0;
	}
	public void RNG()
	{
		print ("running the RNG.....");
		dropCheck = Random.Range (0,101);
		print ("You got a " + dropCheck);
		checkForSpawn ();
	}

	void spawnPowerup ()
	{
		print ("Spawning powerup! ");
		powerupNumber = Random.Range (0,2);
		print ("You got a " + powerupNumber);

		if (powerupNumber == 0) {
			//spawn an hp drop

			GameObject hpPowerup = (GameObject) Instantiate(HPUp,location,
				Quaternion.identity);
		}

		else if (powerupNumber == 1) {
			//spawn a triple shot
			GameObject TripleShot = (GameObject) Instantiate(tripleShot,location,
				Quaternion.identity);

		}

		else if (powerupNumber == 2) {
			//spawn a rapid fire
			GameObject RapidFire = (GameObject) Instantiate(rapidFire,location,
				Quaternion.identity);

		}
	}
}
