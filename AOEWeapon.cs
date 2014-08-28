using UnityEngine;
using System.Collections;

public class AOEWeapon : WeaponHandler {
	
	bool isFire;
	float nextFire;
	public static bool aoeHasAmmo;
	public static int aoeAmmo;
	public GameObject aoe;
	
	//If the player has selected the "Fire1" button, it changes the bool isFire to true
	void checkFire(){
		if(Input.GetButtonDown("Fire1")){
			isFire = true;
		}
		else{
			isFire = false;
		}
	}
	
	//If isFire equals true, it creates a clone gameobject and shoots it forward
	//After a shot is fired, aoeAmmo is returned to 0
	void Fire(){
		if(isFire == true && nextFire < Time.time){
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			clone.rigidbody.AddForce(0,100,0);
			clone.tag = "Rocket";
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0, 100));
			Physics.IgnoreCollision(clone.collider, transform.root.collider);
			aoeAmmo = 0;
		}
	}
	
	//If the player has 4 aoeAmmo, aoeHasAmmo will equal to true. False if else
	void checkAmmo(){
		if(aoeAmmo > 3){
			aoeHasAmmo = true;
		}
		else{
			aoeHasAmmo = false;
		}
	}
	
	// Use this for initialization
	void Start () {
		//aoe = Resources.LoadAssetAtPath("Assets/Resources/AOE_Bullet.prefab", typeof(GameObject)) as GameObject;
		this.bullet = aoe;
		this.fireRate = 2;
		isFire = false;
		nextFire = Time.time;
		aoeAmmo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0){
			checkAmmo();
			//if aoeHasAmmo equals true and WeaponHandler's aoeSelected bool variable equals true;
			//checks if the player is firing and will fire when prompted
			if(aoeHasAmmo == true){
				if(WeaponHandler.aoeSelected == true){
					checkFire();
					Fire();
				}
			}
		}
	}
}
