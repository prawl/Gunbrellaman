using UnityEngine;
using System.Collections;

public class LavaRiver : MonoBehaviour {

	public Collider lava1;
	public GameObject lava2;
	public float burn;
	public Collider playerCol;
	public bool burning;
	public GameObject fire;
	public GameObject player;
	public AudioClip lavaSound;
	public float lavaTime;
	
	void OnTriggerEnter(Collider other){
		if(other == playerCol){
			burning = true;
			fire.active = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other == playerCol){
			burning = false;
			fire.active = false;
		}
	}
	
	// Use this for initialization
	void Start () {
		burning = false;
		fire.active = false;
		lavaTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(burning == true && Time.timeScale > 0){
			if(lavaTime < Time.time){
				audio.clip = lavaSound;
				audio.Play();
				audio.loop = false;
				lavaTime = Time.time + 60;
			}
			Player.health = Player.health - 1f;
		}
	}
}
