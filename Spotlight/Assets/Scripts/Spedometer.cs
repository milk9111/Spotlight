using UnityEngine;
using UnityEngine.UI;

public class Spedometer : MonoBehaviour {

    public GameObject text;
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            float vel = Mathf.Abs(player.GetComponent<Rigidbody>().velocity.x + player.GetComponent<Rigidbody>().velocity.y);

            //converts the velocity in m/s into mph
            int speed = Mathf.FloorToInt(vel / 0.44704f);

            text.GetComponent<Text>().text = "" + speed + " MPH";
        }
	}
}
