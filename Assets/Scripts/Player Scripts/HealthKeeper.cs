using UnityEngine;
using System.Collections;

public class HealthKeeper : MonoBehaviour {

	public GUIText healthText;
	public int playerHP = 5;

	void Start () 
	{
		UpdateHealth ();
	}

	public void SubtractOneHealth()
	{
		playerHP--;
		if (playerHP <= 0) 
		{
			playerHP = 0;
		}
		UpdateHealth ();
	}

	public void AddOneHealth()
	{
		playerHP++;
		if (playerHP >= 5) 
		{
			playerHP = 5;
		}
		UpdateHealth ();
	}

	void UpdateHealth()
	{
		if (playerHP == 5) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (0, 77, 191, 255);
		}
		if (playerHP == 4) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (48, 102, 204, 255);
		}
		if (playerHP == 3) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (95, 144, 216, 255);
		}
		if (playerHP == 2) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (146, 178, 225, 255);
		}
		if (playerHP == 1) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (205, 218, 239, 255);
		}
		if (playerHP == 0) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255, 255, 255, 255);
		}

		healthText.text = "Health: " + playerHP + "/5";
	}
		
}
