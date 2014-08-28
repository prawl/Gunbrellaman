using UnityEngine;
using System.Collections;

public class MGBullet : MonoBehaviour {
	
	public Transform explosion;

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
