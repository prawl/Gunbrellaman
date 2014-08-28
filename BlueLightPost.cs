using UnityEngine;
using System.Collections;

public class BlueLightPost : CharacterObject {
	
	public GameObject post;
	public static float distance;
	public float delay;
	public float healthTotal;
	public bool canHeal;
	public float coolDownTime;
	public float lastUsed;
	public bool coolingDown;
	public float currentTime;
	public GameObject effect;
	public Light test;
	public GUIStyle blue;
	public GameObject blue2;
	
	//Prompts a gui message if distance between the player and bluelight is less than 4
	void OnGUI(){
		if(canHeal == true && distance < 4){
			GUI.Box (new Rect (Screen.width/2,Screen.height/2,200,50), new GUIContent("Hold E to Heal"), blue);
		}
	}
	
	// Use this for initialization
	void Start () {
		this.target = GameObject.FindGameObjectWithTag("Player");
		coolingDown = false;
		canHeal = true;
		healthTotal = 44;
	}
	
	//If the player has healed as much as possible from the blue light post
	//The blue light will have a cool down time of 20 seconds
	void coolDown(){
		canHeal = false;
		coolingDown = true;
		coolDownTime = Time.time + 20;
	}
	
	//If coolDownTime is less than the current time and coolingDown is false
	//the player can be healed a total of 44*2.5 points
	void healReady(){
		if(coolDownTime < Time.time && coolingDown == true){
			canHeal = true;
			coolingDown = false;
			healthTotal = 44;
		}
	}
	
	//If the player hasn't used the blue light post for 20 seconds,
	//The blue light post is reset to its default values
	void checkIdle(){
		if(lastUsed < Time.time){
			healthTotal = 44;
			canHeal = true;
		}
	}
	
	//If the player can heal itself on the blue light post, the blue lights will stay on
	//Else, the lights will be turned off
	void checkLight(){
		if(healthTotal <= 0){
			test.enabled = false;
			blue2.active = false;
		}
		else{
			test.enabled = true;
			blue2.active = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkLight();
		currentTime = Time.time;
		Vector3 postPos = post.transform.position;
		Vector3 objPos = target.transform.position;
		//Gets the distance between the player and the blue light post
		distance = Vector3.Distance(objPos, postPos);
		//If coolingDown is true, will check until coolDownTime is less than the current Time
		if(coolingDown == true){
			healReady();
		}
		//Checks if the player is not using the blue light post
		checkIdle ();
		//If the distance is less than 4 and Time.timeScale is running at realtime
		if(distance < 4 && Time.timeScale > 0){
			//If the player can heal itself and the player is holding down the E button,
			//The player will be healed  2.5 points for every healthTotal int
			//The player can only be healed as long as its total health is less than its maximum possible health
			if(Input.GetKey(KeyCode.E)&&(Time.time > delay) && canHeal == true){
				delay = Time.time + .2f;
				lastUsed = Time.time + 20;
				if(Player.health > 0 &&  Player.health < 260 && healthTotal > 0){
					Instantiate(effect, target.transform.position, target.transform.rotation);
					healthTotal = healthTotal-1;
					Player.health = Player.health+5f;
				}
				if(healthTotal == 0){
					coolDown();
				}
			}
		}
	}
}
