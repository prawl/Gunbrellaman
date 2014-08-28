using UnityEngine;
using System.Collections;

public class AOEAmmo : AOEWeapon {
	
	public GameObject aoeAmmo;
	public float distance;
	public GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.transform.position;
		Vector3 objPos = aoeAmmo.transform.position;
		distance = Vector3.Distance(objPos, targetPos);
		//If the distance between the ammo drop and player is less than 3,
		//it checks if the aoeAmmo is less than 5; if it is, it adds one to
		//aoeAmmo and destroys the game object
		if(distance < 3){
			if(AOEWeapon.aoeAmmo < 5){
				AOEWeapon.aoeAmmo++;
				Destroy(gameObject);
			}
		}
	}
}
