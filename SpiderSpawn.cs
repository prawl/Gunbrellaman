using UnityEngine;
using System.Collections;

public class SpiderSpawn : CharacterObject {
	
	public GameObject Enemy;
	public Transform myTransform;
	public Transform explosionPrefab;
	public ContactPoint contact;
	public Vector3 pos;
	public Quaternion rot;
	public static bool levelOne;
	public static bool levelTwo;
	public static bool levelThree;
	public float maxHealth = 10;
	public float maxSpeed = 5;
	public float maxRot = 5;
	public int deadCount;
	public GameObject cube;
	
	void OnCollisionEnter(Collision collision) {
		if(health > 0){
	        if(collision.gameObject.tag == "Bullet" && deadCount < 1){
				health = 0;
			}
			if(collision.gameObject.tag=="MG" && deadCount < 1) {
	     		health = 0;
	   		}
	   		if(collision.gameObject.tag=="Rocket" && deadCount < 1) {
	   			health = 0;
	   		}
			if(collision.gameObject.tag=="AOE" && deadCount < 1){
				health = -10;
			}
		}
	}
	
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 10f;
			maxSpeed = 5.0f;
			maxRot = 5.0f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth = 10f;
			maxSpeed = 5.5f;
			maxRot = 5.5f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 10f;
			maxSpeed = 6.0f;
			maxRot = 6.0f;
		}
	}
	
	void getTransform(){
		myTransform = Enemy.transform;
	}

	void isDead(){
		if(deadCount == 1){
			Destroy (Enemy);
			rot = cube.transform.rotation;
			pos = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z);
			Instantiate(explosionPrefab, pos, rot);
		}
		else{
		}
	}
	
	void attackTarget(){
		animation.Play("Spider Walk Cycle");
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
		if(health <= 0){
			deadCount++;
			isDead();
		}
		if(deadCount < 1){
			attackTarget();
		}
	}	
}
