using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public GameObject PlayerBullet;
	public GameObject BulletPosition;
	private HealthKeeper healthKeeper;
	private SpawnerScript spawnerScript;
	public GUIText youLoseText;
	public bool powerThreeShot = false;

	public float threeShotStartTime = -1000f;
	public float threeShotDuration = 5f;

	public bool powerRapidFire = false;
	public float rapidFireStartTime = -1000f;
	public float rapidFireDuration = 4f;

	private float shotCD = .25f;
	private float shotCDStartTime;
	private bool canIShoot = true;

	public float playerHealth = 5.0f;

	Vector3 mousePosition;
	Vector3 direction;
	public Quaternion rotation;

	private float spreadAngle = 5f;

	public GameObject PlayAgain;

	public float speed = 10.0f;

	void Start ()
	{
		GameObject playerHealthObject = GameObject.FindWithTag ("HealthKeeper");
		if (playerHealthObject != null) {
			healthKeeper = playerHealthObject.GetComponent <HealthKeeper> ();
		}
		if (healthKeeper == null) {
			//Debug.Log ("Can't find 'HealthKeeper' script");
		}

		spawnerScript = GetComponent<SpawnerScript> ();
		//PlayAgainButton ();

	}

	void Update ()
	{
		//print (powerThreeShot);
		if (powerThreeShot) {
			if(Time.time>=threeShotDuration+threeShotStartTime)	{
				powerThreeShot = false;
				ChangeColor();
			}
		}
		if (powerRapidFire) {
			if(Time.time>=rapidFireDuration+rapidFireStartTime)	{
				shotCD = .25f;
				powerRapidFire = false;
				ChangeColor();
			}
			else {
				shotCD = .10f;
			}
		}
		if (canIShoot == false) {
			if (Time.time >= shotCD + shotCDStartTime) {
				canIShoot = true;
			}
		}

		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		if (Input.GetMouseButton(0) ) {

			if(canIShoot)
			{
				if (powerThreeShot == false){
					GameObject bul = (GameObject)Instantiate (PlayerBullet);
					bul.transform.position = transform.position;

					mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					mousePosition.z = 0.0f;
					direction = (mousePosition - transform.position).normalized;
					bul.GetComponent<PlayerBulletScript> ().buldirection = direction;
					canIShoot = false;
					shotCDStartTime = Time.time;
				}

				if (powerThreeShot == true){

					mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					mousePosition.z = 0.0f;
					direction = (mousePosition - transform.position).normalized;
					direction = Quaternion.Euler(0, 0, -spreadAngle) * direction;

					for (int i = 0; i < 3; i++){
						GameObject bul = (GameObject)Instantiate (PlayerBullet);
						bul.transform.position = transform.position;
						Vector3 intendedDirection;
						intendedDirection = Quaternion.Euler(0,0,direction.z + (i*spreadAngle)) * direction;
						bul.GetComponent<PlayerBulletScript> ().buldirection = intendedDirection;
					}
					canIShoot = false;
					shotCDStartTime = Time.time;
				}
			}

		}

		rotation = Quaternion.LookRotation
			(mousePosition - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  movement
		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey("d"))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey("w"))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey("s"))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}



//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  detect death of player
		if (playerHealth <= 0) {
			youLoseText.text = "YOU LOSE";

			print ("you lose");
			//youLoseText.enabled = true;
			PlayAgain.SetActive (true);
			Destroy (gameObject);

		}

		//OUT OF BOUNDS CHECK
		if (transform.position.x > 15f) {
			transform.position = new Vector3(15f,transform.position.y,0);
		}
		if (transform.position.x < -15f) {
			transform.position = new Vector3(-15f,transform.position.y,0);
		}
		if (transform.position.y > 8f) {
			transform.position = new Vector3(transform.position.x,8f,0);
		}
		if (transform.position.y < -8f) {
			transform.position = new Vector3(transform.position.x,-8f,0);
		}
	}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  detect collisions
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemy") {		//when hit by enemy
			onHit ();
			onHit ();	//loss 2 hp for enemy collision
		}

		if (coll.gameObject.tag == "EnemyBullet") {	//when hit by enemy bullet
			onHit ();

		}
	}
	public void ChangeColor(){

		//print ("Changing color");

			if (playerHealth == 5) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (0f, 1f, 0f, 1);
			}
			if (playerHealth == 4) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.21f, 0.9f, 0.21f, 1);
			}
			if (playerHealth == 3) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.45f, 0.86f, 0.45f, 1);
			}
			if (playerHealth == 2) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.67f, 0.9f, 0.67f, 1);
			}
			if (playerHealth == 1) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			}
			if(powerThreeShot){
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 1f, 1);
			}
		if(powerRapidFire){
				this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 0f, 1);
			}
	}

	//////  what happens when hit
	void onHit (){
		playerHealth--;
		healthKeeper.SubtractOneHealth ();
		ChangeColor ();
	}

	/*void PlayAgainButton()
	{
		PlayAgain.GetComponent<Button> ().onClick.AddListener (GameOverCommence);
	}*/

	public void LoadScene(int level)
	{
		//loadingImage.SetActive(true);
		Application.LoadLevel(level);
	}

	public void threeShotActivate (){
		//threeShotDuration = 5f;
		threeShotStartTime = Time.time;
		powerThreeShot = true;
		//threeShotStartTime
		ChangeColor ();

	}

	public void rapidFireActivate (){
		rapidFireStartTime = Time.time;
		powerRapidFire = true;
		ChangeColor ();
	}
	/*public void GameOverCommence()
	{
		spawnerScript.SpawnerReset ();
	}*/
}
