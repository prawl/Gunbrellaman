using UnityEngine;
using System.Collections;

public class HealthObject : CharacterObject {
	
	public GameObject health;
	public float distance;

	// Use this for initialization
	void Start () {
		this.target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.transform.position;
		Vector3 objPos = health.transform.position;
		distance = Vector3.Distance(objPos, targetPos);
		if(distance < 3){
			if(Player.health < 260){
				GunbrellaAudio.healthBox = true;
				if(Player.health + 40 > 260){
					Player.health = 260;
					Destroy(gameObject);
				}
				else{
					Player.health = Player.health+40;
					Destroy(gameObject);
				}
			}
		}
	}
}
