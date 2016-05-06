using UnityEngine;
using System.Collections;

public class turnoffAfter : MonoBehaviour {

	public GUIText me;
	public float timeTurnedOn;
	// Use this for initialization
	void OnAwake () {
		//timeTurnedOn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeTurnedOn + 6f) {
			me.text = "";
		}
	}
}
