using UnityEngine;
using System.Collections;

public class MGAmmo : MGWeapon {
	
	public GameObject mgAmmo;
	public float distance;
	public GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.transform.position;
		Vector3 objPos = mgAmmo.transform.position;
		distance = Vector3.Distance(objPos, targetPos);
		if(distance < 3){
			if(MGWeapon.mgAmmo < 200){
				if(MGWeapon.mgAmmo + 50 > 200){
					MGWeapon.mgAmmo = 200;
					Destroy(gameObject);
				}
				else{
					MGWeapon.mgAmmo = MGWeapon.mgAmmo + 50;
					Destroy(gameObject);
				}
			}
		}
	}
}

