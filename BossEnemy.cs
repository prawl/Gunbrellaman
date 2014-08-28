using UnityEngine;
using System.Collections;

public class BossEnemy : CharacterObject {
	
	public AudioClip backoffClip;
	public GameObject Enemy;
	public Transform myTransform;
	public float distance;
	public GameObject acidBall;
	public GameObject fireBall;
	public GameObject forceBlast;
	public float fireRate = 2;
	public float nextFire;
	public int chooseAttack;
	public int deadCount;
	public Vector3 pos;
	public Transform explosionPrefab;
	public Transform finalBlast;
	public Transform demonPrefab;
	public Quaternion rot;
	public static bool levelOne;
	public static bool levelTwo;
	public static bool levelThree;
	public float maxHealth;
	public float maxSpeed = 4;
	public float maxRot = 4;	
	public static float health;
	public GameObject fireLoc;
	public GameObject acidLoc;
	public GameObject crows;
	public GameObject floating;
	public GameObject backOff;
	public int number;
	
	float currentTime;
	
	//Checks collisions on the gameObject, depending on the 
	//gameObject; can damage the gameObject's health
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet"){
			health = health - 2;
			animation.Play("Demon Hit");
		}
		if(collision.gameObject.tag=="MG") {
     		health = health - 3;
			animation.Play("Demon Hit");
   		}
	}
	
	//Based on number of enemies left in the spawner class,
	//the gameObject's stats can be increased the closer to 0
	//the spawner is
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 200f;
			maxSpeed = 7f;
			maxRot = 7f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth =300f;
			maxSpeed = 7.5f;
			maxRot = 7.5f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 1000f;
			maxSpeed = 8f;
			maxRot = 8f;
		}
	}
	
	//The gameObject's Vector3 location
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	//Shoots a fireball projectile towards the player
	IEnumerator fire(){
		yield return new WaitForSeconds(.3f);	
		GameObject clone = Instantiate (fireBall, fireLoc.transform.position, fireLoc.transform.rotation) as GameObject;
		clone.rigidbody.AddForce(0,100,0);
		clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
		clone.collider.tag = "fireBall";
		Destroy(clone, 1);
	}
	
	//Shoots an acidball projectile towards the player
	IEnumerator acid(){
		yield return new WaitForSeconds(.3f);	
			GameObject clone = Instantiate (acidBall, acidLoc.transform.position, acidLoc.transform.rotation) as GameObject;
			clone.rigidbody.AddForce(0,100,0);
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
			clone.collider.tag = "acidBall";
			Destroy(clone, 1);
	}
	
	//If the gameObject's health is less than 0; 2 possible death animations can occur
	//Depending on if the gameObject is the finalboss or not
	IEnumerator death(){
		if(GameController.finalBoss == true){
			rot = crows.transform.rotation;
			pos = crows.transform.position;
			if(number < 1){
				Instantiate(finalBlast, pos, rot);
				number++;
			}
			Destroy(gameObject);
		}
		else{
			animation.Play("Demon Float");
			rot = crows.transform.rotation;
			pos = crows.transform.position;
			if(number < 1){
				Instantiate(explosionPrefab, pos, rot);
				number++;
			}
			yield return new WaitForSeconds(1f);
			Destroy(gameObject);
		}		
	}
	
	//Starts the death animation for the gameObject
	void isDead(){
			Destroy(gameObject.collider);
			Destroy(gameObject.rigidbody);
			animation.Play("Demon Death");
			StartCoroutine(death());	
	}
	
	//If the player's distance to the gameObject is less than 8; the gameObject will shoot
	//a clone projectile at the player with the tag "forceBlast"
	void tooClose(){
		animation.Play("Demon Float");
		if(Time.time - currentTime > 2){
			currentTime = Time.time;
			audio.clip = backoffClip;
			audio.Play ();
			audio.loop = false;
		}
		
		GameObject clone = Instantiate (forceBlast, backOff.transform.position, backOff.transform.rotation) as GameObject;
		Instantiate(demonPrefab, floating.transform.position, floating.transform.rotation);
		clone.rigidbody.AddForce(0,100,0);
		clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
		Physics.IgnoreCollision(clone.collider, Enemy.transform.root.collider);
		clone.collider.tag = "forceBlast";
		Destroy(clone, 2);
	}
	
	//Makes the gameObject's rotation equal to the player's Vector3 location
	void faceTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
	}
	
	//Updates the distance between the player and the gameObject
	void updateDistance(){
		distance = Vector3.Distance(Enemy.transform.position, target.transform.position);
	}
	
	//The gameObject will move toward the player
	void goToTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
		animation.Play ("Demon Walk Cycle");
	}
	
	//A random number is generated. Based on the number generated; the gameObject will either
	//shoot a fireball or an acidball
	void Attack(){
		chooseAttack = Mathf.Abs (Random.Range(1,10));
		if(chooseAttack > 0 && chooseAttack < 5){
			nextFire = Time.time + fireRate;
			animation.Play("Demon Acid Attack");
			StartCoroutine(acid ());
		}
		else{
			nextFire = Time.time + fireRate;
			animation.Play ("Demon Fire Attack");
			StartCoroutine(fire());
		}
		
	}
	
	//Initalizes gameObject variables
	void Start(){
		currentTime = Time.time;
		checkLevelOne();
		checkLevelTwo();
		checkLevelThree();
		health = maxHealth;
		this.moveSpeed = maxSpeed;
		this.rotationSpeed = maxRot;
		this.target = GameObject.FindGameObjectWithTag("Player");
		getTransform();
		number = 0;
	}
	
	//Checks every frame the distance between the player and the gameObject
	//if the gameObject's health is less than 0, and if the gameObject can
	//attack the player
	void Update(){
		if(GameController.finalBoss == true){
			fireRate = 2;	
		}
		else{
			fireRate = 3;	
		}
		if(health < 0){
			isDead();
			GameController.bossInPlay = false;
		}
		else{
			updateDistance();
			faceTarget();
			if(distance > 20){
				goToTarget();
			}
			if(distance < 20 && Time.time > nextFire && distance >= 8){
				animation.Play ("Demon Standing");
				Attack();
			}
			if(distance < 8){
				tooClose();	
			}
		}
	}
}
