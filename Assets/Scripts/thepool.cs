using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class thepool : MonoBehaviour {
	bool AddShit = true;

	public GameObject playerBulletPrefab;
	public GameObject enemyBulletPrefab;
	public GameObject triangleEnemyPrefab;
	public GameObject bomberEnemyPrefab;

	public List<GameObject> enemyBulletList;
	public List<GameObject> playerBulletList;

	public List<GameObject> triangleEnemyList;
	public List<GameObject> bomberEnemyList;

	GameObject enemyBulletClone;
	GameObject playerBulletClone;
	GameObject triangleEnemyClone;
	GameObject bomberEnemyClone;

	// Use this for initialization
	void Awake () {
		//print ("make the Lists");
		enemyBulletList = new List<GameObject>();
		playerBulletList = new List<GameObject>();

		triangleEnemyList = new List<GameObject>();
		bomberEnemyList = new List<GameObject>();


		//bullet pools
		for(int i=0;i<=300;i++)
		{
			
			 enemyBulletClone = (GameObject)Instantiate(enemyBulletPrefab);
		
			enemyBulletClone.name = enemyBulletClone.name + i;
			enemyBulletClone.SetActive(false);
			enemyBulletList.Add(enemyBulletClone);

			playerBulletClone = (GameObject)Instantiate(playerBulletPrefab);

			playerBulletClone.name = playerBulletClone.name + i;
			playerBulletClone.SetActive(false);
			playerBulletList.Add(playerBulletClone);
		}

		//enemy pools
		for(int i = 0; i<=75;i++)
		{
			//  for(int i = 0; i < numEnemies; i++)
			 triangleEnemyClone = (GameObject)Instantiate(triangleEnemyPrefab);

			triangleEnemyClone.name = triangleEnemyClone.name + i;
			triangleEnemyClone.SetActive(false);
			triangleEnemyList.Add(triangleEnemyClone);
			
			 bomberEnemyClone = (GameObject)Instantiate(bomberEnemyPrefab);

			//bomberEnemyList.Add(bomberEnemyClone);
			bomberEnemyClone.name = bomberEnemyClone.name + i;
			bomberEnemyClone.SetActive(false);
			bomberEnemyList.Add (bomberEnemyClone);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (AddShit) {
			
		}
	
	}

	public GameObject CheckForInactiveTriangle()
	{
		foreach (GameObject triangle in triangleEnemyList) {
			if(triangle.activeInHierarchy == true)
			{
				continue;
			}
				return triangle;
		}
		return null;
	}

	public GameObject CheckForInactiveBomber()
	{
		foreach (GameObject bomber in bomberEnemyList) {
			if(bomber.activeInHierarchy == true)
			{
				continue;
			}
				return bomber;
		}
		return null;
	}

	public GameObject CheckForInactivePlayerBullet()
	{
		//print ("in check for inactive player bullet");
		foreach (GameObject bullet in playerBulletList) {
			if(bullet.activeInHierarchy == true)
			{
				continue;

			}
				return bullet;

		}
		return null;
	}

	public GameObject CheckForInactiveEnemyBullet()
	{
		foreach (GameObject bullet in enemyBulletList) {
			if(bullet.activeInHierarchy == true)
			{
				continue;
			}
				return bullet;

		}
		return null;
	}

}
