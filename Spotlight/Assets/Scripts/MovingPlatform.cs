using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Transform farEnd;
    public Vector3 frometh;
    private Vector3 untoeth;
    public float speed;
    public float t;
    

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        //in order to reset all moving objects in the scene (except for player),
        //using Vector3.Lerp the variable of "t" must be equals to 0. Right now
        //this is being set to 0 in the Restart() method of the ButtonNextLevel script.
        t += Time.deltaTime;

        //moves the platforms, use large numbers to slow down speed, small
        //numbers to increase speed.
        transform.position = Vector3.Lerp(frometh, untoeth,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(t / speed, 1f)));
    }
}
