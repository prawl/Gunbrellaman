using UnityEngine;
using System.Collections;

public class BomberEnemy : CharacterObject {
	
	public GameObject Enemy;
	public Transform myTransform;
	public Transform explosionPrefab;
	public ContactPoint contact;
	public Vector3 pos;
	public Quaternion rot;	
	
	//If anything collides with the gameObject, the gameObject will be destroyed
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet"){
			contact = collision.contacts[0];
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			Destroy (Enemy);
		}
		if(collision.gameObject.tag=="MG") {
     		contact = collision.contacts[0];
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			Destroy (Enemy);
   		}
   		if(collision.gameObject.tag=="Rocket") {
   			contact = collision.contacts[0];
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			Destroy (Enemy);
   		}
		if(collision.gameObject.tag=="Player") {
   			contact = collision.contacts[0];
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			Destroy (Enemy);
   		}
		if(collision.gameObject.tag=="Explosion") {
   			contact = collision.contacts[0];
			rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			Destroy (Enemy);
   		}
	}
	
	//Gets the gameObject's Vector3 location
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	//If the enemy's health is less than 1, the gameObject is destroyed
	void isDead(){
		if(health < 1.0){
			Destroy(Enemy);
		}
		else{
		}
	}
	
	//The gameObject will go toward the player's current location and collide with the player
	void attackTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
	}
	
	//Initilizes the gameObject's health, movement speed, and rotation speed. Also selects the player as the target
	void Start(){
		this.health = 10;
		this.moveSpeed = 10;
		this.rotationSpeed = 8;
		this.target = GameObject.FindGameObjectWithTag("Player");
		getTransform();
	}
	
	//Checks if the player is dead, if not; the gameObject will attack the player.
	void Update(){
		isDead ();
		attackTarget();
	}	
}
