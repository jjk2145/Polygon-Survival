using UnityEngine;
using System.Collections;

public class PowerThreeShot : MonoBehaviour {
	public GameObject player;
	private PlayerScript playerScript;
	
	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent < PlayerScript > ();

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
		playerScript.powerThreeShot = true;
		print ("3 shot");
		Destroy (gameObject);
	}
}
