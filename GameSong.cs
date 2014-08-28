using UnityEngine;
using System.Collections;

public class GameSong : MonoBehaviour {
	
	public AudioClip gameSong;
	
	// Use this for initialization
	void Start () {
		audio.clip = gameSong;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
