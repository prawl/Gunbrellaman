using UnityEngine;
using System.Collections;

public class Spawner : GameController {
	public static int waveLength;
	public static int onField;
	public static int bossOn;
	public static int maxOn;
	public GameObject[] enemies;
	public static float delay;
	public int randomPick;
	public GameObject[] spawnPoints;
	public GameObject currentSpawn;
	public GameObject ranged;
	public GameObject melee;
	public GameObject wizard;
	public int spawnNum;
	public int maxSpawn;
	public GameObject spawnEffect;
	
	// Use this for initialization
	void Start () {
		waveLength = 66;
		onField = 0;
		bossOn = 0;
		delay = 0;
		maxOn = 6;
		spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
		maxSpawn = spawnPoints.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0){
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			onField = enemies.Length;
			if(onField < maxOn && waveLength > 0 && delay < Time.time){
				spawnNum = Mathf.Abs(Random.Range(1, maxSpawn));
				currentSpawn = spawnPoints[spawnNum];
				randomPick = Mathf.Abs(Random.Range(1,40));
				if(randomPick > 0 && randomPick < 4){
					delay = Time.time + 2;
					onField++;
					waveLength--;
					Instantiate(spawnEffect, currentSpawn.transform.position, currentSpawn.transform.rotation);
					GameObject clone = Instantiate(ranged, currentSpawn.transform.position, currentSpawn.transform.rotation) as GameObject;
					clone.tag = "Enemy";
				}
				if(randomPick > 4 && randomPick < 6){
					delay = Time.time + 2;
					onField++;
					waveLength--;
					Instantiate(spawnEffect, currentSpawn.transform.position, currentSpawn.transform.rotation);
					GameObject clone = Instantiate(wizard, currentSpawn.transform.position, currentSpawn.transform.rotation) as GameObject;
					clone.tag = "Enemy";
				}
				else{
					delay = Time.time + 2;
					onField++;
					waveLength--;
					Instantiate(spawnEffect, currentSpawn.transform.position, currentSpawn.transform.rotation);
					GameObject clone = Instantiate(melee, currentSpawn.transform.position, currentSpawn.transform.rotation) as GameObject;
					clone.tag = "Enemy";
				}
			}
		}
	}
}
