using UnityEngine;
using System.Collections;

public class SpiderDeathSpawner : MonoBehaviour {
	
	public GameObject spawn;
	public GameObject littleSpider;
	
	IEnumerator Spawner(){
			Instantiate(littleSpider, spawn.transform.position, spawn.transform.rotation);
			yield return new WaitForSeconds(.5f);			
	}
	
	// Update is called once per frame
	void Update () {
		spawn = GameObject.FindGameObjectWithTag("BigSpiderDeath");
		StartCoroutine(Spawner());
	}
}
