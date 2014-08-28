using UnityEngine;
using System.Collections;

public class MainWeapon : WeaponHandler {
	
	bool isFire;
	float nextFire;
	public GameObject main;
	public AudioClip shot;
	
	void checkFire(){
		if(Input.GetButtonDown("Fire1")){
			isFire = true;
		}
		else{
			isFire = false;
		}
	}
	
	void Fire(){
		if(isFire == true){
			audio.clip = shot;
			audio.volume = .3f;
			audio.Play();
			GameObject clone = Instantiate (bullet, transform.position, transform.rotation) as GameObject;
			clone.tag = "Bullet";
			clone.rigidbody.AddForce(0,50,0);
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0, 100));
			Physics.IgnoreCollision(clone.collider, transform.root.collider);
	 		Destroy(clone, 1);
		}
	}
	
	// Use this for initialization
	void Start () {
		//main = Resources.LoadAssetAtPath("Assets/Resources/Bullet.prefab", typeof(GameObject)) as GameObject;
		this.bullet = main;
		isFire = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0){
			if(WeaponHandler.mainSelected == true){
				checkFire();
				Fire();
			}
		}
	}
}
