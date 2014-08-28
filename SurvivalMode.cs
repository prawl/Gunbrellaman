using UnityEngine;
using System.Collections;

public class SurvivalMode : MonoBehaviour {
		
	public float minutes;
	public float seconds;
	public float timer;
	public float startTime;
	public GUIStyle myStyle;
	public GUIStyle myStyle2; // For the end msg
	int displayMinutes;
	public float screenHeight;
	public float screenWidth;
	public float btnWidth; // used for the gui box
	public float btnHeight;// used for the gui box
	public float btnWidth2; // used for the gui button
	public float btnHeight2;// used for the gui button
	public float pos1Height;
	public float pos2Height;
	public float pos1Width;
	public float pos2Width;
	public float mult1;
	public float mult2;
	
	
	void OnGUI(){
		if(seconds == 60){
			displayMinutes = (int)minutes+1;
			GUI.Box(new Rect(Screen.width-100,0,100,50), displayMinutes+":00" , myStyle);
		}else
		if(seconds < 10){
			GUI.Box(new Rect(Screen.width-100,0,100,50), minutes+":0"+seconds , myStyle);
		}else
		GUI.Box(new Rect(Screen.width-100,0,100,50), minutes+":"+seconds , myStyle);
		if(Player.health <= 0){
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;            
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;            
      		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;      
			GameObject.Find ("Weapon").GetComponent<WeaponHandler>().enabled = false;
			Time.timeScale = 0;
      		Screen.showCursor = true;
			GUI.Box(new Rect(Screen.width/2-225, Screen.height/2-20, 450,40),"You Are Dead! You Survived For: "+minutes+" minutes and " + seconds +" seconds." + "Try Again?");
			if(GUI.Button (new Rect(Screen.width/2-225, Screen.height/2+20, 450,40), "Yes")){
				Application.LoadLevel("SurvivalMode");	
			}
			if(GUI.Button(new Rect(Screen.width/2-225, Screen.height/2+60, 450,40), "No")){
				Application.LoadLevel("MainMenu");
			}	
		}
	}
	
	void startTimer(){
		startTime = Time.time;	
	}
	
	void calcTimer(){
		timer = Time.time - startTime;
	}
	
	void secondCheck(){
		seconds = Mathf.RoundToInt(timer%60);
	}
	
	void minuteCheck(){
		minutes = Mathf.Floor(timer/60);
	}
	
	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		
		mult1 = .45f;
		mult2 = .50f;
		
		btnWidth = screenWidth / 2;
		btnHeight = screenHeight /3 ;
		btnWidth2 = btnWidth / 3;
		btnHeight2 = btnHeight / 3;
		pos1Height = .60f;
		pos2Height = .60f;
		pos2Width = 1.05f;
		pos1Width = .6f;
		
		
		startTimer();
		MeleeEnemy.levelTwo = true;
		WizardEnemy.levelTwo = true;
		RangedEnemy.levelTwo = true;
		minutes = 0;
		seconds = 0;
	}
	
	// Update is called once per frame
	void Update () {
		calcTimer();
		secondCheck();
	    minuteCheck();
	}
}
