using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

	public GameObject thePool;
	thepool PoolScript;

	float timeEnabled = 0f;
	float lifeTime = 6f;

	float speed;
	public Vector3 buldirection = Vector3.zero;
	public float rotateTo = 0;
	// Use this for initialization


	void OnEnable () {
		speed = 10f;
		//print (rotateTo);
		//transform.Rotate (0,0,rotateTo);

		transform.position += buldirection * .725f;

		timeEnabled = Time.time;
		//Destroy (gameObject, 6f);

	}
	
	// Update is called once per frame
	void Update () {

		/*Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));*/

		//transform.Rotate (buldirection);
		transform.position += buldirection * speed * Time.deltaTime;

		if (Time.time > timeEnabled + lifeTime) {
			gameObject.SetActive(false);
		}

		/*if (transform.position.y > max.y) {
		
			Destroy (gameObject);

		}*/
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemy") {
			gameObject.SetActive(false);
			//Destroy (gameObject);
		}
	}
}
