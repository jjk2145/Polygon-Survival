using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public GUIText scoreText;
	public int score;


	// Use this for initialization
	void Start () {
		UpdateScore ();
	}

	public void AddScoreSmall()
	{
		score += 1;
		UpdateScore ();
	}

	public void AddScore()
	{
		score += 50;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
