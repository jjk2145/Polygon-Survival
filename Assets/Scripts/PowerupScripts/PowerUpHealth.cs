using UnityEngine;
using System.Collections;

public class PowerUpHealth : MonoBehaviour {

	public GameObject player;
	private PlayerScript playerScript;
	private HealthKeeper healthKeeper;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent < PlayerScript > ();
		GameObject playerHealthObject = GameObject.FindWithTag ("HealthKeeper");
		if (playerHealthObject != null) {
			healthKeeper = playerHealthObject.GetComponent <HealthKeeper> ();
		}
		else {
			//Debug.Log ("Can't find 'HealthKeeper' script");
		}
		//print ("Yay I'm alive hp boost");
		Destroy(gameObject, 4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {		//when hit by player
			onHit ();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  what happens when hit
	void onHit (){
		if (playerScript.playerHealth == 5) {
			Destroy (gameObject);
		} else {
			playerScript.playerHealth++;
			healthKeeper.AddOneHealth ();
			playerScript.ChangeColor ();
			Destroy (gameObject);
		}

	}
}
