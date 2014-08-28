using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Portal;
	public float distance;
	public AudioClip sound1;
	public AudioClip sound2;
	public int soundOne;
	public int soundTwo;
	
	//If the distance between the portal and the player is less than 5; the portal will load "Loading Level 3"
	void CheckIfLoad(){
		if(distance < 5){
			Application.LoadLevel("Loading Level 3"); 	
		}
	}
	
	//Starts the game with Time progressing in realtime and soundOne and Two equal to 0
	void Start(){
		Time.timeScale = 1;	
		soundOne = 0;
		soundTwo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Updates distance between player and the portal
		distance = Vector3.Distance(Player.transform.position, Portal.transform.position);
		CheckIfLoad();
		//If the distance is less than 60; plays an audio clip. Increases soundOne once so audio doesn't loop
		if(distance < 60 && soundOne == 0){
			audio.clip = sound1;
			audio.Play();
			audio.loop = false;
			soundOne++;
		}
		//If the distance is less than 20; plays an audio clip. Increases soundOne once so audio doesn't loop
		if(distance < 20 && soundTwo == 0){
			audio.clip = sound2;
			audio.Play();
			audio.loop = false;
			soundTwo++;
		}
	}
}
