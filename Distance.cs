using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {
	public GameObject Enemy;
	public GameObject target;
	public float distance;
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag("Player");
		distance = Vector3.Distance(Enemy.transform.position, target.transform.position);
		print (distance);
	}
}
