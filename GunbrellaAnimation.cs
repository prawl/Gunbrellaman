using UnityEngine;
using System.Collections;

public class GunbrellaAnimation : MonoBehaviour {
	
	float walkSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		walkSpeed = Input.GetAxis("Vertical");
		
		if(WeaponHandler.mgSelected && MGWeapon.mgAmmo > 0 && Input.GetButton("Fire1")){
			animation.Play("Gunbrella_Shoot");
		}
		
		if(Input.GetButtonDown("Fire1")){
			animation.Play("Gunbrella_Shoot");	
		}
		
		if(walkSpeed == 0 && !animation.IsPlaying("Gunbrella_Shoot") && !animation.IsPlaying("Gunbrella_move")){
			animation.Play("Gunbrella_Idle");
		}
		
		if(walkSpeed !=0 && !animation.IsPlaying("Gunbrella_Shoot")){
			animation.Play ("Gunbrella_move");
		}
	}
}
