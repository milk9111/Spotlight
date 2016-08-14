using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour {

    public int milliseconds;
    public int seconds;
    public int minutes;
    public GameObject text;
    public GameObject hiScore;
    public bool keepGoing;
    float score;
    public float bScore;
    public string bestScore;


    void Start()
    {
        hiScore.GetComponent<Text>().text = bestScore;
        bScore = 60;
        keepGoing = true;
        milliseconds = 0;
        seconds = 0;
        minutes = 0;
    }

    public void setKeepGoing(bool theValue)
    {
        keepGoing = theValue;
    }

    void FixedUpdate()
    {

        if (keepGoing)
        {
            if (milliseconds < 59)
            {
                milliseconds++;
            }
            else
            {
                milliseconds = 0;
                if (seconds < 59)
                {
                    seconds++;
                }
                else
                {
                    minutes++;
                    seconds = 0;
                }
            }           
            GetComponent<Text>().text = minutes + " : " + seconds + " : " + milliseconds;                       
        }
        else
        {
            score = minutes + (float)seconds / 60 + (float)milliseconds / 3600;
            if (score < bScore)
            {
                bScore = score;
            }
            int bMilli = (int)(bScore / 60 * 3600);
            int bSec = (int)(bScore / 60);
            int bMin = (int)(bScore - (bScore / 60 + bScore / 60 * 3600));
            bestScore = bMin + " : " + bSec + " : " + bMilli;
           // Debug.Log(bestScore);
        }
    }
}
