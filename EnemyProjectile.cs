using UnityEngine;
using System.Collections;

public class EnemyProjectile : CharacterObject {
	
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
	public float maxSpeed = 20;
	public float maxRot = 20;
	public GameObject mgAmmo;
	public GameObject aoeAmmo;
	public GameObject healthDrop;
	public int deadCount;
	
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet" && deadCount < 1){
			contact = collision.contacts[0];
			health = health - 5;
		}
		if(collision.gameObject.tag=="MG" && deadCount < 1) {
			contact = collision.contacts[0];
     		health = health - 10;
   		}
   		if(collision.gameObject.tag=="Rocket" && deadCount < 1) {
			contact = collision.contacts[0];
   			health = 0;
   		}
		if(collision.gameObject.tag=="Explosion" && deadCount < 1){
			contact = collision.contacts[0];
			health = 0;
		}
	}
	
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 40f;
			maxSpeed = 4.5f;
			maxRot = 4.5f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth = 50f;
			maxSpeed = 5f;
			maxRot = 5f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 60f;
			maxSpeed = 5.5f;
			maxRot = 5.5f;
		}
	}
	
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	IEnumerator explode(){
			yield return new WaitForSeconds(1.95f);			
			Instantiate(explosionPrefab, pos, rot);
	}
	
	void isDead(){
		if(deadCount == 1){
			Destroy(gameObject.collider);
			Destroy (Enemy, 2);
			rot = Enemy.transform.rotation;
			pos = new Vector3(myTransform.position.x+1, myTransform.position.y, myTransform.position.z+3);
			StartCoroutine(explode());	
		}
		else{
		}
	}
	
	void attackTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
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
		levelOne = false;
		levelTwo = false;
		levelThree = false;
		getTransform();
	}
	
	void Update(){
		if(health < 0){
			deadCount++;
			isDead();
		}
		if(deadCount < 1){
			//attackTarget();
		}
	}	
}
