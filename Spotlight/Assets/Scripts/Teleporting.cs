using UnityEngine;
using System.Collections;

public class Teleporting : MonoBehaviour {

	public GameObject teleportOut;

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player") {
			c.gameObject.transform.position = teleportOut.transform.position;
		}
	}

}
