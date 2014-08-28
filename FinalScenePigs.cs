using UnityEngine;
using System.Collections;

public class FinalScenePigs : MonoBehaviour {
	
	public GameObject pig;
	public GameObject player;
	public float rotationSpeed;
	public float moveSpeed;
	
	//Makes the gameObject face the player
	void faceTarget(){
		var lookDir = player.transform.position - pig.transform.position; lookDir.y = 0;
		pig.transform.rotation = Quaternion.Slerp (pig.transform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
	}
	
	//The gameObject will move toward the player
	void goToTarget(){
		var lookDir = player.transform.position - pig.transform.position; lookDir.y = 0;
		pig.transform.position += pig.transform.forward * moveSpeed * Time.deltaTime;	
	}

	// Use this for initialization
	void Start () {
		moveSpeed = 1f;
		rotationSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(FinalScene.phase1 == true){
			faceTarget();
		}
		if(FinalScene.phase2 == true){
			goToTarget();
		}
	}
}
