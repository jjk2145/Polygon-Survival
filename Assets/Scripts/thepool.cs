using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class thepool : MonoBehaviour {

	public GameObject playerBulletPrefab;
	public GameObject enemyBulletPrefab;
	public GameObject triangleEnemyPrefab;
	public GameObject bomberEnemyPrefab;

	List<GameObject> enemyBulletList;
	List<GameObject> playerBulletList;

	List<GameObject> triangleEnemyList;
	List<GameObject> bomberEnemyList;

	// Use this for initialization
	void Start () {

		enemyBulletList = new List<GameObject>();
		playerBulletList = new List<GameObject>();

		triangleEnemyList = new List<GameObject>();
		bomberEnemyList = new List<GameObject>();


		//bullet pools
		for(int i=0;i>=300;i++)
		{
			GameObject enemyBulletClone = (GameObject)Instantiate(enemyBulletPrefab);
			enemyBulletList.Add(enemyBulletClone);
			enemyBulletClone.name = enemyBulletClone.name + i;
			enemyBulletClone.SetActive(false);

			GameObject playerBulletClone = (GameObject)Instantiate(playerBulletPrefab);
			playerBulletList.Add(playerBulletClone);
			playerBulletClone.name = playerBulletClone.name + i;
			playerBulletClone.SetActive(false);
		}

		//enemy pools
		for(int i=0;i>=75;i++)
		{
			GameObject triangleEnemyClone = (GameObject)Instantiate(triangleEnemyPrefab);
			triangleEnemyList.Add(triangleEnemyClone);
			triangleEnemyClone.name = triangleEnemyClone.name + i;
			triangleEnemyClone.SetActive(false);
			
			GameObject bomberEnemyClone = (GameObject)Instantiate(bomberEnemyPrefab);
			bomberEnemyList.Add(bomberEnemyClone);
			bomberEnemyClone.name = bomberEnemyClone.name + i;
			bomberEnemyClone.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckForInactive()
	{
		foreach (GameObject triangle in triangleEnemyList) {

		}
	}
}
