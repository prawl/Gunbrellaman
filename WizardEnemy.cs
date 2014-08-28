using UnityEngine;
using System.Collections;

public class WizardEnemy : CharacterObject {
	
	public GameObject Enemy;
	public Transform myTransform;
	public float distance;
	public GameObject bomber;
	public GameObject enemyBullet;
	int randomWizard =  new int();
	public float fireRate = 5;
	public float nextFire;
	public int whichAttack;
	public int deadCount;
	public Vector3 pos;
	public Transform explosionPrefab;
	public Quaternion rot;
	public static bool levelOne;
	public static bool levelTwo;
	public static bool levelThree;
	public float maxHealth = 60;
	public float maxSpeed = 4;
	public float maxRot = 4;
	public GameObject mgAmmo;
	public GameObject aoeAmmo;
	public GameObject healthDrop;
	public GameObject Anus;
	public GameObject cube;
	public GameObject acidBall;
	
	
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet" && deadCount < 1){
			animation.Play("Spider Hit");
			health = health - 2;
		}
		if(collision.gameObject.tag=="MG" && deadCount < 1) {
			animation.Play("Spider Hit");
     		health = health - 5;
   		}
   		if(collision.gameObject.tag=="Rocket" && deadCount < 1) {
			animation.Play("Spider Hit");
   			health = 0;
   		}
		if(collision.gameObject.tag=="AOE" && deadCount < 1){
			health = -10;
		}
	}
	
	void checkLevelOne(){
		if(levelOne == true){
			maxHealth = 80f;
			maxSpeed = 5f;
			maxRot = 5f;
		}
	}
	
	void checkLevelTwo(){
		if(levelTwo == true){
			maxHealth = 90f;
			maxSpeed = 5.5f;
			maxRot = 5.5f;
		}
	}
	
	void checkLevelThree(){
		if(levelThree == true){
			maxHealth = 100f;
			maxSpeed = 6f;
			maxRot = 6f;
		}
	}
	
	void getTransform(){
		myTransform = Enemy.transform;
	}
	
	IEnumerator explode(){
			yield return new WaitForSeconds(1.95f);			
			Instantiate(explosionPrefab, pos, rot);
	}
	
	void isDead(){
		if(deadCount == 1){
			checkIfDrop();
			GunbrellaAudio.pickLine = Mathf.Abs (Random.Range(1,9));
			animation.Play("Spider Death");
			Destroy(gameObject.collider);
			Destroy(gameObject.rigidbody);
			Destroy (Enemy, 2);
			rot = Enemy.transform.rotation;
			pos = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z+3);
			StartCoroutine(explode());	
		}
		else{
		}
	}
	
	void checkIfDrop(){
		randomWizard = Mathf.Abs(Random.Range(1, 30));
		if(randomWizard >= 4 && randomWizard <= 8){
			GameObject item = healthDrop;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomWizard >= 9 && randomWizard <= 14){
			GameObject item = mgAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
		if(randomWizard >= 1 && randomWizard <= 3){
			GameObject item = aoeAmmo;
			GameObject clone = Instantiate(item, myTransform.position, myTransform.rotation) as GameObject;
		}
	}

	
	void faceTarget(){
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed*Time.deltaTime);
	}
	
	void updateDistance(){
		distance = Vector3.Distance(Enemy.transform.position, target.transform.position);
	}
	
	void goToTarget(){
		animation.Play("Spider Walk Cycle");
		var lookDir = target.transform.position - myTransform.position; lookDir.y = 0;
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;	
	}
	
	IEnumerator attack(){
		whichAttack = Mathf.Abs (Random.Range(1,10));
		if(whichAttack > 0 && whichAttack < 4){
			animation.Play("Spider Fire");
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (enemyBullet, Anus.transform.position, Anus.transform.rotation) as GameObject;
			clone.rigidbody.AddForce(0,100,0);
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
			Physics.IgnoreCollision(clone.collider, Enemy.transform.root.collider);
			clone.collider.tag = "freezeGun";
			Destroy(clone, 2);
		}
		if(whichAttack > 4 && whichAttack < 8){
			animation.Play("Spider Fire");
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (acidBall, Anus.transform.position, Anus.transform.rotation) as GameObject;
			clone.rigidbody.AddForce(0,100,0);
			clone.rigidbody.velocity = transform.TransformDirection(new Vector3 (0,0,50));
			Physics.IgnoreCollision(clone.collider, Enemy.transform.root.collider);
			clone.collider.tag = "acidBall";
			Destroy(clone, 2);
		}
		else{
			animation.Play("Spider Spawning");
			nextFire = Time.time + fireRate;
			GameObject enemyClone1 = Instantiate(bomber, cube.transform.position, cube.transform.rotation) as GameObject;
			Physics.IgnoreCollision(enemyClone1.collider, Enemy.transform.root.collider);
			yield return new WaitForSeconds(.5f);
			GameObject enemyClone2 = Instantiate(bomber, cube.transform.position, cube.transform.rotation) as GameObject;
			Physics.IgnoreCollision(enemyClone2.collider, Enemy.transform.root.collider);
			yield return new WaitForSeconds(.5f);
			GameObject enemyClone3 = Instantiate(bomber, cube.transform.position, cube.transform.rotation) as GameObject;
			Physics.IgnoreCollision(enemyClone3.collider, Enemy.transform.root.collider);
			enemyClone1.collider.tag = "Bomber";
			enemyClone2.collider.tag = "Bomber";
			enemyClone3.collider.tag = "Bomber";
		}
		
	}
	
	void Start(){
		checkLevelOne();
		checkLevelTwo();
		checkLevelThree();
		this.health = maxHealth;
		this.moveSpeed = maxSpeed;
		this.rotationSpeed = maxRot;
		this.target = GameObject.FindGameObjectWithTag("Player");
		getTransform();
	}
	
	void Update(){
		if(health < 0){
			deadCount++;
			isDead();
		}
		if(deadCount < 1){
			updateDistance();
			faceTarget();
			if(distance > 20){
				goToTarget();
			}
			if(distance < 20 && Time.time > nextFire){
				StartCoroutine(attack());
			}
		}
	}
}
