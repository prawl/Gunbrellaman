using UnityEngine;
using System.Collections;

public class Player : GameController {	
	
	public static float health;
	public GUITexture healthBar;
	public GUITexture sprintBar;
	public GUITexture circle;
	public CharacterController character;
	public int count;
	public bool acid;
	public float wait;
	public bool blast;
	public float coolDown;
	public int num;
	public Camera mainCam;	
	public Collider fireBall;
	public Collider acidBall;
	public Collider webAttack;
	public AudioClip ouch1;
	public AudioClip ouch2;
	public AudioClip ouch3;
	public AudioClip ouch4;
	public AudioClip ouch5;
	public int ouchInt;
	public float waitSpeak;
	
	void OnCollisionEnter(Collision collision){
   		if(collision.gameObject.tag=="Melee" && health > 0) {
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
	   		health = health-5;
   		}
   		if(collision.gameObject.tag=="Enemy Bullet" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
	   		health = health - 10;
   		}
		if(collision.gameObject.tag=="SpiderSpawn" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			health = health - 2.5f;
		}
		if(collision.gameObject.tag=="forceBlast" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			character.Move(Vector3.forward*50);
			blast = true;
		}
		if(collision.gameObject.tag=="fireBall" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			health = health - 15;
		}
		if(collision.gameObject.tag=="acidBall" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			health = health - 5;
			acid = true;
		}
		if(collision.gameObject.tag=="MinotaurHead" && health > 0){
			ouchInt = Mathf.Abs(Random.Range(1,30));
			if(ouchInt == 1 && waitSpeak < Time.time){
				audio.clip = ouch1;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 2 && waitSpeak < Time.time){
				audio.clip = ouch2;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 3 && waitSpeak < Time.time){
				audio.clip = ouch3;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 4 && waitSpeak < Time.time){
				audio.clip = ouch4;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			if(ouchInt == 5 && waitSpeak < Time.time){
				audio.clip = ouch5;
				audio.Play();
				audio.loop = false;
				waitSpeak = waitSpeak + 2;
			}
			health = health - 7.5f;
		}
	}	
	
	void acidBurn(){
		if(count >= 10){
			acid = false;
			count = 0;
		}
		else{
			if(wait < Time.time){
				health = health-5;
				wait = Time.time + 1;
				count++;
			}
		}
	}
	
	void AfterEffect(){
		if(num >= 10){
			blast = false;
			num = 0;
			mainCam.GetComponent<MotionBlur>().enabled = false;
			mainCam.GetComponent<NoiseEffect>().enabled = false;
		}
		else{
			mainCam.GetComponent<MotionBlur>().enabled = true;
			mainCam.GetComponent<NoiseEffect>().enabled = true;
			if(coolDown < Time.time){
				coolDown = Time.time +1;
				num++;
			}
		}
	}
	
	void updateGUI(){
		healthBar.pixelInset = new Rect(156.9f,-61.7f, Player.health ,11.1f);
		sprintBar.pixelInset = new Rect(159.2f,-71.76f,CharacterMotor.sprintTime,7.2f);
		//circle.pixelInset = new Rect(0, -242.4f, 1029.9f, 266.6f);
	}
	
	// Use this for initialization
	void Start () {
		wait = Time.time;
		waitSpeak = Time.time;
		acid = false;
		count = 0;
		Time.timeScale = 1;
		health = 260;
		character = GetComponent<CharacterController>();
		mainCam.GetComponent<MotionBlur>().enabled = false;
		mainCam.GetComponent<NoiseEffect>().enabled = false;
	}
	
	void Update(){

		updateGUI();
		if(blast == true){
			AfterEffect();
		}
		if(acid == true){
			acidBurn();
		}
		if(Time.timeScale == 0){
			GetComponent<GUICrosshair>().enabled = false;
		}
		else{
			GetComponent<GUICrosshair>().enabled = true;
		}
	}
	
	
}
