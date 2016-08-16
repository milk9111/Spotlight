using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnlockButtons : MonoBehaviour {

	public Button[] buttons;
	public static int finishedLevels = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= finishedLevels; i++) {
			buttons [i].interactable = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
