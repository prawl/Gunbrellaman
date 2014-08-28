using UnityEngine;
using System.Collections;

public class CharacterObject : Spawner {
	
	public float health {get; set;}
	public float moveSpeed {get; set;}
	public float rotationSpeed {get; set;}
	public GameObject target {get; set;}
	public GameObject item;
}
