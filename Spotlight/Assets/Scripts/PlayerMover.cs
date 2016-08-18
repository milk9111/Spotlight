using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerMover : MonoBehaviour {

    public float speed;
    public float jumpHeight;

    public GameObject player;
    public GameObject RestartButton;
    public GameObject winMessage;
    public GameObject pauseMessage;
    public GameObject levelSelectButton;
    public GameObject nextLevelButton;
    public GameObject timer;

    public GameObject myExplosion;

    public bool isDone;
    private bool canDoubleJump = false;

    private Vector3 distToGround;

    void Start()
    {
        //Cursor.visible is also being set in the Restart
        //method of ButtonNextLevel script.
        Cursor.visible = false;
        Time.timeScale = 1;
        RestartButton.SetActive(false);
        winMessage.SetActive(false);
        levelSelectButton.SetActive(false);
        nextLevelButton.SetActive(false);

        isDone = false;

        distToGround = GetComponent<Collider>().bounds.extents;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
		{
            Cursor.visible = true;
            TimerCount time = timer.GetComponent<TimerCount>();
            time.setKeepGoing(false);
            RestartButton.SetActive(true);
            levelSelectButton.SetActive(true);
            
            Instantiate(myExplosion, transform.position, Quaternion.identity);
            Destroy(player);
        }
    }

    public bool IsGrounded()
    {
		/*RaycastHit2D[] hits = new RaycastHit2D[2];
		int h = Physics2D.RaycastNonAlloc (transform.position, -Vector2.up, hits);

		float angle;
		bool jump = false;
		if (h > 1) {
			angle = Mathf.Abs (Mathf.Atan2 (hits [1].normal.x, hits [1].normal.y) * Mathf.Rad2Deg);
			angle = angle * Mathf.Deg2Rad;
			jump = Physics2D.Raycast(transform.position, new Vector2 (Mathf.Sin(angle), Mathf.Cos(angle)));
		}*/



        bool jump = Physics.Raycast(transform.position, -Vector2.up, distToGround.y + 0.1f);
		//check 45 degree on right side
		jump = jump || Physics.Raycast(transform.position, Vector2.right - Vector2.up, distToGround.x + 0.1f);
		//check 45 degree on left side
		jump = jump || Physics.Raycast(transform.position, -Vector2.right - Vector2.up, distToGround.x + 0.1f);
		if (jump) {
			return jump;
		} else {
			return jump;
		}
    }

    public bool GetIsDone()
    {
        return isDone;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            TimerCount time = timer.GetComponent<TimerCount>();
            time.setKeepGoing(false);
            Cursor.visible = true;

            winMessage.SetActive(true);
            RestartButton.SetActive(true);
            levelSelectButton.SetActive(true);
            nextLevelButton.SetActive(true);

			checkTimeScale ();

            isDone = true;
        }
    }

    void Update () {
        if (!isDone)
        {
            //pause game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseGame();
            }

            //move right
            if (Input.GetKey(KeyCode.D) && GetComponent<Rigidbody>().velocity.x <= 40)
            {
                GetComponent<Rigidbody>().AddForce(speed, 0, 0, ForceMode.Impulse);
            }

            //move left
            if (Input.GetKey(KeyCode.A) && GetComponent<Rigidbody>().velocity.x >= -40)
            {
                GetComponent<Rigidbody>().AddForce(-speed, 0, 0, ForceMode.Impulse);
            }

            //jump
            if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Rigidbody>().velocity.y <= 40)
            {
                if (IsGrounded())
                {
                    GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                    canDoubleJump = true;
                }
                else if (canDoubleJump)
                {
                    GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                    canDoubleJump = false;
                }
            }

            //apply speed downwards (in order to gain momentum on curves or as another way to slow yourself down)
            if (Input.GetKey(KeyCode.S) && GetComponent<Rigidbody>().velocity.y >= -40)
            {
                GetComponent<Rigidbody>().AddForce(0, -jumpHeight, 0, ForceMode.Acceleration);
            }
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }
    }

    private void pauseGame()
    {
        Cursor.visible = !Cursor.visible;
        pauseMessage.SetActive(!pauseMessage.activeSelf);
        RestartButton.SetActive(!RestartButton.activeSelf);
        levelSelectButton.SetActive(!levelSelectButton.activeSelf);

		checkTimeScale();
    }

	private void checkTimeScale()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
}
