using UnityEngine;
using System.Collections;

public class WeaponHandler : Player {
	
	public GameObject bullet {get;set;}
	public float fireRate {get;set;}
	public float fireSpeed {get;set;}
	public static bool mainSelected;
	public static bool mgSelected;
	public static bool aoeSelected;
	int weaponNum;
	public GUITexture mainWeapon;
	public GUITexture aoeWeapon;
	bool first;
	bool aoeFirst;
	
	void getWeapon(){
		
		//Case where you get Ammo for the first time
		if(first == true && MGWeapon.mgHasAmmo == true){
			first = false;
			weaponNum = 6;
		}
		if(aoeFirst == true && AOEWeapon.aoeHasAmmo == true){
			aoeFirst = false;
			weaponNum = 10;
		}
		
		
		//Switch weapon to active when out of Ammo
		if(weaponNum >= 10 && weaponNum <=12 && !AOEWeapon.aoeHasAmmo){
			weaponNum = 9;
		}
		if(weaponNum >=5 && weaponNum <=9 && !MGWeapon.mgHasAmmo){
			weaponNum = 1;
		} 
		
		//Assign Weapon based on scroller position
		if(weaponNum >= 10 && weaponNum <=12){
			mainSelected = false;
			mgSelected = false;
			aoeSelected = true;
			mainWeapon.enabled = false;
			aoeWeapon.enabled = true;
		}else
		if(weaponNum >=5 && weaponNum <=9){
			mainSelected = false;
			mgSelected = true;
			aoeSelected = false;
			mainWeapon.enabled = false;
			aoeWeapon.enabled = false;
		}else{
			mainSelected = true;
			mgSelected = false;
			aoeSelected = false;
			mainWeapon.enabled = true;
			aoeWeapon.enabled = false;
		}
	}
	
	// Use this for initialization
	void Start () {
		weaponNum = 1;
		first = true;
		aoeFirst = true;
	}
	
		
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") < 0){//back
			weaponNum--;
		}
		if(Input.GetAxis("Mouse ScrollWheel") > 0){//forward
			weaponNum++;
		}
		if(weaponNum > 12){
			weaponNum = 1;
		}
		if(weaponNum < 1){
			weaponNum = 12;
		}
		getWeapon();
	}
}
