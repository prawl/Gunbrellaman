using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject Boss;
	public static int bossOn;
	public GameObject bossSpawn;
	public static bool gameWon;
	public static bool bossInPlay;
	public static bool finalBoss;
	public GameObject goodPortal;
	public GameObject capsule;
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI(){
		if(Player.health <= 0 && Application.loadedLevelName.Equals("Hell_Level") == true){
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;            
			GameObject.Find("First Person Controller").GetComponent<CharacterMotor>().enabled = false;            
      		GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;      
			GameObject.Find ("Weapon").GetComponent<WeaponHandler>().enabled = false;
			Time.timeScale = 0;
      		Screen.showCursor = true;
			GUI.Box(new Rect(Screen.width/2.42f, Screen.height/2.35f, 280, 40),"You Are Dead! Try Again?");
			if(GUI.Button (new Rect(Screen.width/2.42f, Screen.height/2.03f, 280, 40), "Yes")){
				Application.LoadLevel("Hell_Level");	
			}
			if(GUI.Button (new Rect(Screen.width/2.42f, Screen.height/1.79f, 280, 40), "No")){
				Application.LoadLevel("MainMenu");
			}	
		}
	}
	
	void Start(){
		Time.timeScale = 1;	
		bossOn = 0;
		bossInPlay = false;
		finalBoss = false;
		gameWon = false;
		goodPortal.active = false;
		capsule = GameObject.FindGameObjectWithTag("Capsule");
		capsule.active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Spawner.waveLength < 45){
			Spawner.maxOn = 8;
			MeleeEnemy.levelOne = true;
			MeleeEnemy.levelTwo = false;
			MeleeEnemy.levelThree = false;
			WizardEnemy.levelOne = true;
			WizardEnemy.levelTwo = false;
			WizardEnemy.levelThree = false;
			BossEnemy.levelOne = true;
			BossEnemy.levelTwo = false;
			BossEnemy.levelThree = false;
			if(bossOn == 0){
				Instantiate(Boss, bossSpawn.transform.position, bossSpawn.transform.rotation);
				bossOn++;
				bossInPlay = true;
			}
		}
		if(Spawner.waveLength < 30){
			Spawner.maxOn = 10;
			MeleeEnemy.levelOne = false;
			MeleeEnemy.levelTwo = true;
			MeleeEnemy.levelThree = false;
			WizardEnemy.levelOne = false;
			WizardEnemy.levelTwo = true;
			WizardEnemy.levelThree = false;
			BossEnemy.levelOne = false;
			BossEnemy.levelTwo = true;
			BossEnemy.levelThree = false;
			if(bossOn == 1 && bossInPlay == false){
				Instantiate(Boss, bossSpawn.transform.position, bossSpawn.transform.rotation);
				bossOn++;
				bossInPlay = true;
			}			
		}
		if(Spawner.waveLength < 15){
			Spawner.maxOn = 12;
			MeleeEnemy.levelOne = false;
			MeleeEnemy.levelTwo = false;
			MeleeEnemy.levelThree = true;
			WizardEnemy.levelOne = false;
			WizardEnemy.levelTwo = false;
			WizardEnemy.levelThree = true;
			BossEnemy.levelOne = false;
			BossEnemy.levelTwo = false;
			BossEnemy.levelThree = true;
		}
		if(Spawner.waveLength <= 0 && Spawner.onField <= 0){
			if(bossOn == 2 && bossInPlay == false){
				Instantiate(Boss, bossSpawn.transform.position, bossSpawn.transform.rotation);
				bossOn++;
				bossInPlay = true;
				finalBoss = true;
			}	
		}
		if(BossEnemy.health <= 0 && bossOn == 3 && finalBoss == true && bossInPlay == false){
			gameWon = true;	
		}
		
		if(gameWon == true){
			goodPortal.active = true;
			goodPortal.GetComponent<GoodPortalController>().enabled = true;
			capsule.active = false;
		}
	}
}
