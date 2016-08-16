using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNextLevel : MonoBehaviour {

    public MovingPlatform[] resetObjects;


    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Cursor.visible = false;

        int index = 0;
        while (index < resetObjects.Length)
        {
            resetObjects[index].t = 0;  
            index++;
        }
    }

    public void NextLevelButton(string theLevelNum)
    {
        SceneManager.LoadScene(theLevelNum);
		//UnlockButtons.finishedLevels++;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
