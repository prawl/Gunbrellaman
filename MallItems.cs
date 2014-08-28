using UnityEngine;
using System.Collections;

public class MallItems : CharacterObject {
	
	public GameObject mallItem;
	
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy"){
			health = health - 10;
		}
	}
	
	void checkIfDead(){
		if(health < 1){
			Destroy(mallItem);
		}
	}

	// Use this for initialization
	void Start () {
		this.health = 30;
	}
	
	// Update is called once per frame
	void Update () {
		checkIfDead();
	}
}
