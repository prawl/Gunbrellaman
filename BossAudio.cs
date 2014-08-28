using UnityEngine;
using System.Collections;

public class BossAudio : MonoBehaviour {
	
	//All possible audio clips the boss character can speak
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
	
	public int bossLine;
	public float shutup;
	
	ArrayList audioList;
	ArrayList secondList;
	
	//Initilizes variables and adds all possble lines to an ArrayList
	void Start(){
		shutup = Time.time;
		audioList = new ArrayList();
		secondList = new ArrayList();
		
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
	}
	
	void Update(){
		bossLine = 1;
		//Reset AudioList when there are no more clips to be played
		if(audioList.Count == 0){
			ArrayList temp = new ArrayList();
			temp = audioList;
			audioList = secondList;
			secondList = temp;
		}
		
		//Player is allowed to Speak
		if(bossLine > 0 && bossLine < 9 && shutup < Time.time && BossEnemy.health > 0 && BossEnemy.health !=1000){
			
			//Player should speak 10% of the time
			int playNumber = Mathf.Abs (Random.Range(0,9));
			if(playNumber == 1){
				int x = Mathf.Abs (Random.Range(0,audioList.Count));
						
				audio.clip = audioList[x] as AudioClip;
				audio.Play ();
				audio.loop = false;
				shutup = Time.time + 45;
			
				secondList.Add(audio.clip);
				audioList.RemoveAt(x);
			}
			bossLine = 0;
		}
	}
}
