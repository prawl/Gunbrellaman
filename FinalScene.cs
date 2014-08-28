using UnityEngine;
using System.Collections;

public class FinalScene : MonoBehaviour {

	public static bool phase1;
	public static bool phase2;
	public Camera FP;
	public Camera other;
	public float test;
	public AudioClip drama;
	public int soundInt;
	public AudioClip jaws;
	public AudioClip gdT;
	
	void GDT(){
		audio.Stop();
		audio.clip = gdT;
		audio.maxDistance = 100;//50;
		audio.Play();
		soundInt++;
	}	
	
	//At the beginning of the scene, will play the audio clip "drama"
	void PlaySound(){
		audio.clip = drama;
		audio.maxDistance = 120;
		audio.Play();
		soundInt++;
	}
	
	//As the scene progress, changes the values to true after waiting for 
	//a selected number of seconds. Once the selected waiting time has passed
	//for all funtions; will load the main menu
	IEnumerator phaseOne(){
		yield return new WaitForSeconds(2f);
		phase1 = true;
		yield return new WaitForSeconds(4f);
		phase2 = true;
		yield return new WaitForSeconds(2f);
		FP.active = false;
		other.active = true;
		if(test > 30){
			test = test - .25f;
			other.fieldOfView = test;
		}
		phase1 = false;
		phase2 = false;
		if(soundInt < 1){
			PlaySound();
		}
		yield return new WaitForSeconds(7f);
		if(soundInt < 2){
			GDT();
		}
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("MainMenu");
	}
	
	// Use this for initialization
	void Start () {
		FP.active = true;
		other.active = false;
		test = 60;
		soundInt = 0;
		audio.clip = jaws;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(phaseOne());
	}
}
