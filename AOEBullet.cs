using UnityEngine;
using System.Collections;

public class AOEBullet : MonoBehaviour {

	public Transform explosion;
	
	//On collision, the gameobject gets the position and rotation of the collision and creates
	//an explosion at that point
	void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag != "Don't Destroy") {
		collision.transform.SendMessage("BeenHit", SendMessageOptions.DontRequireReceiver);
		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate(explosion, pos, rot);
		Destroy(gameObject);
		}
	}
}
