using UnityEngine;
using System.Collections;

public class RangedEnemy : CharacterObject {

	public GameObject Enemy;
	public Transform myTransform;
	public float distance;
	public GameObject enemyBullet;
	public float fireRate = 5;
	public float nextFire;
	public float meleeFire;
	int randomRanged = new int();
	public Transform monsterPrefab;
	public ContactPoint contact;
	public Vector3 pos;
	public Quaternion rot;
	public static bool levelOne;
	public static bool levelTwo;
	public static bool levelThree;
	public float maxHealth = 50;
	public float maxSpeed = 3;
	public float maxRot = 3;
	public GameObject mgAmmo;
	public GameObject aoeAmmo;
	public GameObject healthDrop;
	public GameObject mouth;
	public GameObject blastPoint;
	public GameObject attackSecret;
	public GameObject crotch;
	public float blast;
	public bool attacking;
	public AudioClip sound1;
	public bool soundPlay;
	public int testie;
	public float soundTime;
	int randomSound = new int();
	
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet"){
			animation.Play("Minotaur Hit");
			health = health - 2;
			contact = collision.contacts[0];
		}
		if(collision.gameObject.tag=="MG") {
			animation.Play("Minotaur Hit");
     		health = health - 3;
			contact = collision.contacts[0];
   		}
   		if(collision.gameObject.tag=="AOE") {
   			health = 0;
			contact = collision.contacts[0];
   		}
	}
	
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 80f;
			maxSpeed = 3.5f;
			maxRot = 3.5f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth = 85f;
			maxSpeed = 4f;
			maxRot = 4f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 90f;
			maxSpeed = 4.5f;
			maxRot = 4.5f;
		}
	}
	
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	void isDead(){
		if(health < 1.0){
			GunbrellaAudio.pickLine = Mathf.Abs (Random.Range(1,9));
			checkIfDrop();
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = myTransform.position;
			//renderer.enabled = false;
			Instantiate(monsterPrefab, blastPoint.transform.position, blastPoint.transform.rotation);
			Destroy(Enemy);
		}
		else{
		}
	}
	
	void checkIfDrop(){
		randomRanged = Mathf.Abs(Random.Range(1,40));
		if(randomRanged >= 4 && randomRanged <= 8){
			GameObject item = healthDrop;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomRanged >= 9 && randomRanged <= 14){
			GameObject item = mgAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomRanged >= 1 && randomRanged <= 3){
			GameObject item = aoeAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
	}
	
	void faceTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
	}
	
	void updateDistance(){
		distance = Vector3.Distance(Enemy.transform.position, target.transform.position);
	}
	
	void goToTarget(){
		animation.Play("Minotaur Walk Cycle");
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
	}
	
	IEnumerator attack(){
		animation.Play("Minotaur Standing");
		nextFire = Time.time + fireRate;
		animation.Play("Minotaur Fire");
		yield return new WaitForSeconds(.5f);
		GameObject clone = Instantiate (enemyBullet, mouth.transform.position, mouth.transform.rotation) as GameObject;
		Physics.IgnoreCollision(clone.collider, Enemy.transform.root.collider);
		Physics.IgnoreCollision(clone.collider, mouth.transform.root.collider);
		clone.rigidbody.AddForce(0,100,0);
		clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
		clone.collider.tag = "Enemy Bullet";
		Destroy(clone, 1);
	}
	
	IEnumerator waitPeriod(){
		yield return new WaitForSeconds(2);
		attacking = false;
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
		randomSound = Mathf.Abs(Random.Range(1,100));
		if(randomSound == 1 && soundPlay == false){
			audio.clip = sound1;
			audio.Play();
			audio.loop = false;
			soundPlay = true;
		}
	}
	
	IEnumerator meleeAttack(){
		animation.Play("Minotaur Standing");
		meleeFire = Time.time + 1;
		animation.Play("Minotaur Fire");
		yield return new WaitForSeconds(.5f);
		GameObject clone1 = Instantiate (attackSecret, crotch.transform.position, crotch.transform.rotation) as GameObject;
		Physics.IgnoreCollision(clone1.collider, Enemy.transform.root.collider);
		Physics.IgnoreCollision(clone1.collider, crotch.transform.root.collider);
		clone1.rigidbody.AddForce(0,100,0);
		clone1.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
		clone1.collider.tag = "MinotaurHead";
		Destroy(clone1, 1);
	}
	
	void tooClose(){
		animation.Play("Minotaur Walk Cycle");
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
	}
	
	void Start(){
		checkLevelOne();
		checkLevelTwo();
		checkLevelThree();
		this.health = maxHealth;
		this.moveSpeed = maxSpeed;
		this.rotationSpeed = maxRot;
		this.target = GameObject.FindGameObjectWithTag("Player");
		getTransform();
		blast = Time.time;
		attacking = false;
		testie = 0;
		soundTime = Time.time;
		soundPlay = false;
	}
	
	void Update(){
		isDead ();
		updateDistance();
		faceTarget();
		PlaySound();
		if(distance > 10){
			goToTarget();
			attacking = false;
		}
		if(distance < 10 && 8 < distance){
			if(nextFire < Time.time){
				StartCoroutine(attack ());
				attacking = true;
				StartCoroutine(waitPeriod());
			}
			if(attacking == false){
				animation.Play("Minotaur Standing");	
			}
		}
		if(distance < 8 && distance > 1.5f){
			tooClose();	
		}
		if(distance < 1.5f && meleeFire < Time.time){
			StartCoroutine(meleeAttack());
		}
	}	
}
