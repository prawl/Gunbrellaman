using UnityEngine;
using System.Collections;

public class WalkingSounds : MonoBehaviour {
	
	public AudioClip walking;
	float walkingLength;
	float currentTime;
	
	bool isWalking(){
		if(Input.GetKey (KeyCode.A))return true;
		if(Input.GetKey (KeyCode.S))return true;
		if(Input.GetKey (KeyCode.D))return true;
		if(Input.GetKey (KeyCode.W))return true;
		return false;
	}
	
	// Use this for initialization
	void Start () {
		audio.clip = walking;
		audio.volume = 0.02f;
		walkingLength = walking.length;
		currentTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isWalking() && Time.time - currentTime > walkingLength){
			audio.Play();
			audio.loop = false;
			currentTime = Time.time;
		}
		
		if(audio.isPlaying && Input.GetKeyDown(KeyCode.Space)){
			audio.Stop();
			currentTime = Time.time-0.4f;
		}
		/*if((Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))){
			walker = true;
		}
		else{
			walker = false;
		}*/
	}
}
