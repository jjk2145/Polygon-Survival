﻿using UnityEngine;
using System.Collections;

public class PowerRapidFire : MonoBehaviour {

	public GameObject player;
	private PlayerScript playerScript;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent < PlayerScript > ();
		//print ("Yay I'm alive triple shot");
		Destroy(gameObject, 4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		//print ("collision activate tripleshot");
		if (coll.gameObject.tag == "Player") {		//when hit by player 
			onHit ();
		}
	}
	
	//  what happens when hit
	void onHit (){
		playerScript.rapidFireActivate ();
		Destroy (gameObject);
	}
}
