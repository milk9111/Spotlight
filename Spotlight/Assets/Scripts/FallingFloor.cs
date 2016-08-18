using UnityEngine;
using System.Collections;

public class FallingFloor : MonoBehaviour {

	public GameObject thisObject;
	public int secondsTillFall;

	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Player") {
			StartCoroutine(fallAway ());
		}
	}

	IEnumerator fallAway () {
		yield return new WaitForSeconds (secondsTillFall);
		thisObject.GetComponent<MeshRenderer>().enabled = false;
		thisObject.GetComponent<BoxCollider>().enabled = false;
		yield return new WaitForSeconds (secondsTillFall);
		thisObject.GetComponent<MeshRenderer>().enabled = true;
		thisObject.GetComponent<BoxCollider>().enabled = true;
	}
}
