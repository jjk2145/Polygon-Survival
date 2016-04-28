﻿using UnityEngine;
using System.Collections;

public class PowerThreeShot : MonoBehaviour {
	public GameObject player;
	private PlayerScript playerScript;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent < PlayerScript > ();
		print ("Yay I'm alive triple shot");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		print ("collision activate tripleshot");
		if (coll.gameObject.tag == "Player") {		//when hit by player 
			onHit ();
		}
	}
	
	//  what happens when hit
	void onHit (){
		playerScript.threeShotActivate ();
		print ("3 shot");
		playerScript.ChangeColor ();
		Destroy (gameObject);
	}
}