using UnityEngine;
using System.Collections;

public class PowerThing : CharacterObject {
	
	public GameObject power;
	public int availableAmmo;
	public float chargeBack;
	public bool charging;
	public bool canCharge;
	public float lastCharged;
	public float time;
	public float distanceOne;
	public ParticleEmitter test;
	public float pause;
	public GUIStyle powerOne;
	
	void OnGUI(){
		if(availableAmmo > 0 && distanceOne < 4){
			GUI.Box (new Rect (Screen.width/2,Screen.height/2,200,50), new GUIContent("Hold E to Get Ammo"),powerOne);
		}		
	}

	// Use this for initialization
	void Start () {
		this.target = GameObject.FindGameObjectWithTag("Player");
		charging = false;
		canCharge = true;
		availableAmmo = 50;
	}
	
	void coolDown(){
		canCharge = true;
		charging = false;
		chargeBack = Time.time + 60;
	}
		
	void chargeReady(){
		if(chargeBack < Time.time && charging == true){
			canCharge = true;
			charging = false;
			availableAmmo = 50;
		}
	}
	
	void checkIdle(){
		if(lastCharged < Time.time){
			availableAmmo = 50;
			canCharge = true;
		}
	}
	
	void checkPower(){
		if(availableAmmo <= 0){
			test.emit = false;
		}
		else{
			test.emit = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkPower();
		time = Time.time;
		Vector3 boxPos = power.transform.position;
		Vector3 targetPos = target.transform.position;
		distanceOne = Vector3.Distance(boxPos, targetPos);
		if(charging == true){
			coolDown();
		}
		checkIdle ();
		if(distanceOne < 4){
			if(Input.GetKey(KeyCode.E)&&(Time.time > pause) && canCharge == true){
				pause = Time.time + .05f;
				lastCharged = Time.time + 60;

				if(MGWeapon.mgAmmo >= 0 &&  MGWeapon.mgAmmo < 200 && availableAmmo > 0){
					availableAmmo = availableAmmo-1;
					MGWeapon.mgAmmo = MGWeapon.mgAmmo+2;
				}
				if(availableAmmo == 0){
					coolDown();
				}
			}
		}
	}
}
