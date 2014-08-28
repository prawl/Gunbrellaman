using UnityEngine;
using System.Collections;

public class TerrainCheck : MonoBehaviour {
	public GameObject explosion;
	public GameObject afterEffect;
	public GameObject[] bulletEffect;
	public GameObject fire;
	public int length;
	public GameObject bigSpider;
	public GameObject[] melee;
	public GameObject aoe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		aoe = GameObject.FindGameObjectWithTag("AOE");
		Destroy(aoe, 5);
		bigSpider = GameObject.FindGameObjectWithTag("BigSpiderDeath");
		Destroy (bigSpider, 2);
		explosion = GameObject.FindGameObjectWithTag("Explosion");
		Destroy(explosion, 1);
		fire = GameObject.FindGameObjectWithTag("Fire");
		Destroy(fire, 2);
		bulletEffect = GameObject.FindGameObjectsWithTag("BulletEffect");
		length = bulletEffect.Length;
		for(int i = 0; i < length; i++){
			Destroy(bulletEffect[i], .5f);
		}
		afterEffect = GameObject.FindGameObjectWithTag("AfterEffect");
		Destroy (afterEffect,2);
		melee = GameObject.FindGameObjectsWithTag("Melee");
		for(int j = 0; j < melee.Length; j++){
			Destroy (melee[j], 1);	
		}
	}
}
