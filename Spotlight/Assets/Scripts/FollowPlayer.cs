using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Light spotLight;

    public bool isTracking;
    public int modulo;
    public GameObject player;

    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTracking && player != null)
        {
            lockOnPlayer(); 
        }
        else
        {
            //use this with isTracking set to true in order to use mouse tracking (not working correctly)
            if (Input.GetButton("Fire1"))
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        }
    }

    private void lockOnPlayer()
    {
        float vel = player.GetComponent<Rigidbody>().velocity.x + player.GetComponent<Rigidbody>().velocity.y;

        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
        Vector3 delta = player.transform.position
            - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0);
        changeLight(vel);
    }

    private void changeLight(float vel)
    {
        if (Mathf.Abs(vel * modulo) >= 85)
        {
            //changes size of spotlight as velocity increases or decreases
            //NOTE: maybe try using Mathf.Max to decide what the minimum amount will be.
            spotLight.spotAngle = Mathf.Abs(vel * modulo);


            //changes intensity of light
            spotLight.intensity = Mathf.Abs(vel * modulo) / 18;

            //changes size of camera as velocity increases or decreases
            if (Mathf.Abs(vel) >= 17 && Mathf.Abs(vel) <= 25)
            {
                GetComponent<Camera>().orthographicSize = Mathf.Abs(vel) - 7;
            }
            else if (Mathf.Abs(vel) < 17)
            {
                GetComponent<Camera>().orthographicSize = 10;
            }
            else if (Mathf.Abs(vel) > 25)
            {
                GetComponent<Camera>().orthographicSize = 18;
            }

        }
        else if (Mathf.Abs(vel * modulo) < 30 || Mathf.Abs(vel) < 9)
        {
            spotLight.spotAngle = 85;
            spotLight.range = 25;
            spotLight.intensity = 4f;
            GetComponent<Camera>().orthographicSize = 10;
        }
    }
}