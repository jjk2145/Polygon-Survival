using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoolDownTimeKeeper : MonoBehaviour {

	public GUIText CooldownTimerText;
	public Image ThreeShotSprite;
	public Image RapidFireSprite;
	public GameObject player;
	private PlayerScript playerScript;
	private float seconds;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerScript = player.GetComponent < PlayerScript > ();
	}

	void Update(){
		if (playerScript.powerThreeShot == true) {
		    seconds = Mathf.Round ((playerScript.threeShotDuration + playerScript.threeShotStartTime - Time.time) + 0.5f);
			ThreeShotSprite.enabled = true;
			CooldownTimerText.text = "Three Shot Time Remaining : " + seconds + " seconds";
		}
		else if (playerScript.powerRapidFire == true) {
			seconds = Mathf.Round ((playerScript.rapidFireDuration + playerScript.rapidFireStartTime - Time.time) + 0.5f);
			RapidFireSprite.enabled = true;
			CooldownTimerText.text = "Rapid Fire Time Remaining : " + seconds + " seconds";
		}
		else {
			ThreeShotSprite.enabled = false;
			RapidFireSprite.enabled = false;
			CooldownTimerText.text = "No Ability Active";
		}
	}
	

}
