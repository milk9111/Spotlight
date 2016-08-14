using UnityEngine;
using System.Collections;

public class RandomSong : MonoBehaviour {

    public AudioClip[] myMusic;
	
	// Update is called once per frame
	void Update () {
	    if(!GetComponent<AudioSource>().isPlaying)
        {
            PlayRandomSong();
        }
	}

    void PlayRandomSong()
    {
        GetComponent<AudioSource>().clip = myMusic[Random.Range(0, myMusic.Length)];
        GetComponent<AudioSource>().PlayDelayed(2.5f);
    }
}
