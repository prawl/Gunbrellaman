using UnityEngine;
using System.Collections;

public class MeleeEnemy : CharacterObject {
	
	public GameObject Enemy;
	public Transform myTransform;
	int randomMain = new int();
	public Transform explosionPrefab;
	public ContactPoint contact;
	public Vector3 pos;
	public Quaternion rot;
	public static bool levelOne;
	public static bool levelTwo;
	public static bool levelThree;
	public float maxHealth = 30;
	public float maxSpeed = 4;
	public float maxRot = 4;
	public GameObject mgAmmo;
	public GameObject aoeAmmo;
	public GameObject healthDrop;
	public int deadCount;
	public GameObject test;
	public AudioClip sound1;
	public AudioClip sound2;
	public AudioClip sound3;
	int randomSound = new int();
	public bool soundPlay;
	public float soundTime;
	public int testie;
	public float distance;
	public GameObject emptyAttack;
	public float nextFire;
	public GameObject spiderHead;
	
	void OnCollisionEnter(Collision collision) {
		if(health > 0){
	        if(collision.gameObject.tag == "Bullet" && deadCount < 1){
				animation.Play("Spider Hit");
				contact = collision.contacts[0];
				health = health - 2;
			}
			if(collision.gameObject.tag=="MG" && deadCount < 1) {
				animation.Play("Spider Hit");
				contact = collision.contacts[0];
	     		health = health - 5;
	   		}
	   		if(collision.gameObject.tag=="Rocket" && deadCount < 1) {
				animation.Play("Spider Hit");
				contact = collision.contacts[0];
	   			health = 0;
	   		}
			if(collision.gameObject.tag=="AOE" && deadCount < 1){
				animation.Play("Spider Hit");
				contact = collision.contacts[0];
				health = 0;
			}
		}
	}
	
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 50f;
			maxSpeed = 4.5f;
			maxRot = 4.5f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth = 55f;
			maxSpeed = 5f;
			maxRot = 5f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 60f;
			maxSpeed = 5f;
			maxRot = 5f;
		}
	}
	
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	IEnumerator explode(){
			yield return new WaitForSeconds(1.98f);			
			Instantiate(explosionPrefab, pos, rot);
	}
	
	void isDead(){
		if(deadCount == 1){
			GunbrellaAudio.pickLine = Mathf.Abs (Random.Range(1,9));
			checkIfDrop();
			animation.Play("Spider Death");
			Destroy(gameObject.collider);
			Destroy(gameObject.rigidbody);
			Destroy (Enemy, 2);
			rot = Enemy.transform.rotation;
			pos = new Vector3(test.transform.position.x, test.transform.position.y, test.transform.position.z);
			StartCoroutine(explode());	
		}
		else{
		}
	}
	
	void checkIfDrop(){
		randomMain = Mathf.Abs(Random.Range(1,40));
		if(randomMain > 1 && randomMain < 5){
			GameObject item = healthDrop;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomMain > 5 && randomMain < 9){
			GameObject item = mgAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomMain == 1 || (randomMain > 9 && randomMain < 11)){
			GameObject item = aoeAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
	}
	
	void GoToTarget(){
		animation.Play("Spider Walk Cycle");
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		distance = Vector3.Distance(target.transform.position, Enemy.transform.position);
	}
	
	void faceTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);	
	}
	
	void Attack(){
		animation.Play("Spider Fire");	
		nextFire = Time.time + 1.5f;
		GameObject clone = Instantiate(emptyAttack, Enemy.transform.position, Enemy.transform.rotation) as GameObject;
		Physics.IgnoreCollision(clone.collider, Enemy.transform.root.collider);
		clone.rigidbody.AddForce(0,100,0);
		clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
		clone.collider.tag = "Melee";
	}
	
	void UpdateDistance(){
		distance = Vector3.Distance(target.transform.position, Enemy.transform.position);
	}
	
	void PlaySound(){
		if(soundPlay == true){
			testie++;
			if(testie == 1){
				soundTime = Time.time + 2;
			}
			if(soundTime < Time.time){
				soundPlay = false;	
				testie = 0;
			}
		}
		if(soundPlay == false){
			soundTime = Time.time;
		}
		randomSound = Mathf.Abs(Random.Range(1,1000));
		if(randomSound == 1 && soundPlay == false){
			audio.clip = sound1;
			audio.Play();
			soundPlay = true;
		}
		if(randomSound == 2 && soundPlay == false){
			audio.clip = sound2;
			audio.Play();
			soundPlay = true;
		}
		if(randomSound == 3 && soundPlay == false){
			audio.clip = sound3;
			audio.Play();
			soundPlay = true;
		}
	}
	
	void Start(){
		checkLevelOne();
		checkLevelTwo();
		checkLevelThree();
		this.health = maxHealth;
		this.moveSpeed = maxSpeed;
		this.rotationSpeed = maxRot;
		this.target = GameObject.FindGameObjectWithTag("Player");
		levelOne = false;
		levelTwo = false;
		levelThree = false;
		getTransform();
		soundPlay = false;
		soundTime = Time.time;
		testie = 0;
		nextFire = Time.time;
	}
	
	void Update(){
		PlaySound();
		UpdateDistance();
		if(health <= 0){
			deadCount++;
			isDead();
		}
		if(deadCount < 1){
			faceTarget();
			if(distance > 3f){
				GoToTarget();
				nextFire = Time.time;
			}
			if(distance < 3f){
				if(nextFire < Time.time){
					Attack();
				}
			}
		}
	}	
}
