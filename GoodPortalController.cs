using UnityEngine;
using System.Collections;

public class GoodPortalController : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Portal;
	public float distance;
	
	void CheckIfLoad(){
		if(distance < 5){
			Application.LoadLevel("Credits Level"); 	
		}
	}
	
	void Start(){
		Time.timeScale = 1;	
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(Player.transform.position, Portal.transform.position);
		CheckIfLoad();
	}
}
