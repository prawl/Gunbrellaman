using UnityEngine;
using System.Collections;

public class IntroLine : MonoBehaviour {
	
	public AudioClip PlayerClip1;
	public AudioClip PlayerClip2;
	
	public AudioClip EnemyClip1;
	public AudioClip EnemyClip2;
	
	int playerLine;
	int enemyLine;
	
	ArrayList playerList;
	ArrayList enemyList;
	
	int playerPlay;
	int enemyPlay;
	
	float clipTime;
	float currentTime;
	int numberP;
	int numberE;
	
	// Use this for initialization
	void Start () {
		
		playerList = new ArrayList();
		enemyList = new ArrayList();
		
		playerList.Add(PlayerClip1);
		playerList.Add(PlayerClip2);
		
		enemyList.Add (EnemyClip1);
		enemyList.Add (EnemyClip2);
		
		numberP = Mathf.Abs (Random.Range(0,100));
		numberE = Mathf.Abs (Random.Range(0,100));		
		
		if(numberP < 50){
			playerLine = 0;
		}else{
			playerLine = 1;
		}
		if(numberE < 50){
			enemyLine = 0;
		}else{
			enemyLine = 1;
		}
		//playerLine = Mathf.Abs(Random.Range (0,playerList.Count-1));
		//enemyLine = Mathf.Abs(Random.Range (0,enemyList.Count-1));
		
		playerPlay = 0;
		enemyPlay = 0;
		
		currentTime = Time.time;		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(enemyPlay == 0){
			audio.clip = enemyList[enemyLine] as AudioClip;
			clipTime = audio.clip.length;
			audio.Play();
			audio.loop = false;
			enemyPlay = 1;
		}
		
		if(enemyPlay == 1 && Time.time - currentTime > clipTime){
			audio.clip = playerList[playerLine] as AudioClip;
			audio.Play();
			audio.loop = false;
			enemyPlay++;
		}
	}
}
