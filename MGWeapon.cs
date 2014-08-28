using UnityEngine;
using System.Collections;

public class MGWeapon : WeaponHandler {
	
	bool isFire;
	float nextFire;
	public static bool mgHasAmmo;
	public static int mgAmmo;
	public GameObject mg;
	public AudioClip shot;
	
	void checkFire(){
		if(Input.GetButton("Fire1")){
			isFire = true;
		}
		else{
			isFire = false;
		}
	}
	
	void Fire(){
		if(isFire == true && nextFire < Time.time){
			audio.clip = shot;
			audio.Play();
			audio.volume = .5f;
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			clone.tag = "MG";
			clone.rigidbody.AddForce(0,100,0);
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0, 100));
			Physics.IgnoreCollision(clone.collider, transform.root.collider);
			mgAmmo--;
	 		Destroy(clone, 1);
		}
	}
	
	void checkAmmo(){
		if(mgAmmo > 0){
			mgHasAmmo = true;
		}
		else{
			mgHasAmmo = false;
		}
	}
	
	// Use this for initialization
	void Start () {
		//mg = Resources.LoadAssetAtPath("Assets/Resources/MG_Bullet.prefab", typeof(GameObject)) as GameObject;
		this.bullet = mg;
		this.fireRate = 0.1f;
		isFire = false;
		nextFire = Time.time;
		mgAmmo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(mgAmmo > 200){
			mgAmmo = 200;
		}
		
		if(Time.timeScale > 0){
			checkAmmo();
			if(mgHasAmmo == true){
				if(WeaponHandler.mgSelected == true){
					checkFire();
					Fire();
				}
			}
		}
	}
}
