using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadThisScene(string thisScene)
    {
        SceneManager.LoadScene(thisScene);
    }

    public void NextLevel()
    {
        ExitDoor.levelNumber++;
    }

    public void ResetLevel()
    {
        ExitDoor.levelNumber = 0;
        GameTimer.gameTime = 0.0f;
    }
}
