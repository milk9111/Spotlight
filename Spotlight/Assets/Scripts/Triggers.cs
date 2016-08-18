using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Triggers : MonoBehaviour {

    public float newJumpHeight;
    public GameObject tutorial;
    public string tutorialMessage;

    private bool gSwap;
    private GameObject player;

    void Start()
    {
        gSwap = false;
    }

    void FixedUpdate()
    {
        if (gSwap && player != null)
        {
            GravitySwap();
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            gSwap = true;
            player = c.gameObject;
        }
    }

    void OnTriggerEnter(Collider c)
    {
		if (tag == "Tutorial") {
			tutorial.GetComponent<Text> ().text = tutorialMessage;
			tutorial.SetActive (true);
		} 
		/*if (tag == "Teleport") {
			gSwap = false;
			player.GetComponent<Rigidbody>().useGravity = true;
			//player.GetComponent<Rigidbody>().AddForce(0, -5, 0, ForceMode.Acceleration);
		}*/

    }

    void OnTriggerExit(Collider c)
    {
        tutorial.SetActive(false);
    }

    void GravitySwap()
    {
        if (player.GetComponent<Rigidbody>().velocity.y <= 40)
        {
            player.GetComponent<PlayerMover>().jumpHeight = newJumpHeight;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Acceleration);
        }
    }
}
