using UnityEngine;
using System.Collections;

public class SoundSingleton : MonoBehaviour {

    private static SoundSingleton instance = null;
    public static SoundSingleton Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
