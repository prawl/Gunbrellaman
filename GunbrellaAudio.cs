using UnityEngine;
using System.Collections;

public class GunbrellaAudio : MonoBehaviour {
	
	public AudioClip speak1;
	public AudioClip speak2;
	public AudioClip speak3;
	public AudioClip speak4;
	public AudioClip speak5;
	public AudioClip speak6;
	public AudioClip speak7;
	public AudioClip speak9;
	public AudioClip speak10;
	public AudioClip speak11;
	public AudioClip speak12;
	public AudioClip speak13;
	public AudioClip speak14;
	public AudioClip speak15;
	public AudioClip speak16;
	public AudioClip speak17;
	public AudioClip bossDeath;
	public AudioClip speak18;
	public AudioClip speak19;
	public int healthInt;
	public static bool healthBox;
	public int bossDead;
	public int bossOne;
	public int bossTwo;
	public int bossThree;
	public AudioClip laughter;
	public AudioClip laughter2;
	public AudioClip finalBossSound;
	public AudioClip gameOverSound;
	public static int pickLine;
	public float shutup;
	
	ArrayList audioList;
	ArrayList secondList;
	
	void Start(){
		shutup = Time.time;
		audioList = new ArrayList();
		secondList = new ArrayList();
		healthBox = false;
		bossOne = 0;
		bossTwo = 0;
		bossThree = 0;
		audioList.Add(speak1);
		audioList.Add(speak2);
		audioList.Add(speak3);
		audioList.Add(speak4);
		audioList.Add(speak5);
		audioList.Add(speak6);
		audioList.Add(speak7);
		audioList.Add(speak9);
		audioList.Add(speak10);
		audioList.Add(speak11);
		audioList.Add(speak12);
		audioList.Add(speak13);
		audioList.Add(speak14);
		audioList.Add(speak15);
		audioList.Add(speak16);
		audioList.Add(speak17);
		bossDead = 0;
	}
	
	IEnumerator gameOver(){
		yield return new WaitForSeconds(20);
		audio.clip = gameOverSound;
		audio.Play();
		audio.loop = false;
	}
	
	void Update(){
		
		//Reset AudioList when there are no more clips to be played
		if(audioList.Count == 0){
			ArrayList temp = new ArrayList();
			temp = audioList;
			audioList = secondList;
			secondList = temp;
		}
		
		//Player is allowed to Speak
		if(pickLine > 0 && pickLine < 9 && shutup < Time.time){
			
			//Player should speak 10% of the time
			int playNumber = Mathf.Abs (Random.Range(0,9));
			if(playNumber == 1){
				int x = Mathf.Abs (Random.Range(0,audioList.Count));
						
				audio.clip = audioList[x] as AudioClip;
				audio.Play ();
				audio.loop = false;
				shutup = Time.time + 30;
			
				secondList.Add(audio.clip);
				audioList.RemoveAt(x);
			}
			pickLine = 0;
		}
		
		if(GameController.finalBoss == true && GameController.bossInPlay == true && bossThree == 0 && Application.loadedLevelName.Equals("Hell_Level")){
			audio.bypassEffects = true;
			audio.clip = finalBossSound;
			audio.Play();
			audio.loop = false;
			bossThree++;audio.bypassEffects = false;
		}
		
		if(GameController.gameWon == true && bossDead == 0 && Application.loadedLevelName.Equals("Hell_Level")){
			audio.clip = bossDeath;
			audio.Play();
			audio.loop = false;
			bossDead++;
			StartCoroutine(gameOver());
		}
		
		if(GameController.bossInPlay == false && GameController.bossOn == 1 && bossOne == 0 && Application.loadedLevelName.Equals("Hell_Level")){
			audio.clip = laughter;
			audio.Play ();
			audio.loop = false;
			bossOne++;
		}
		
		if(GameController.bossInPlay == false && GameController.bossOn == 2 && bossTwo == 0 && Application.loadedLevelName.Equals("Hell_Level")){
			audio.clip = laughter2;
			audio.Play ();
			audio.loop = false;
			bossTwo++;
		}
		
		if(healthBox == true){
			healthInt = Mathf.Abs(Random.Range(1,10));
			if(healthInt >= 1 && healthInt <= 2 && shutup < Time.time){
				audio.clip = speak18;
				audio.Play();
				audio.loop = false;
				shutup = Time.time + 5;
				healthBox = false;
			}
			if(healthInt >= 3 && healthInt <= 4 && shutup < Time.time){
				audio.clip = speak19;
				audio.Play();
				audio.loop = false;
				shutup = Time.time + 5;
				healthBox = false;
			}
		}
	}
}
