using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevelScript : MonoBehaviour
{
    public void TryAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(SceneManager.GetActiveScene();
    }

    public void QuitGame()
    {
        Debug.Log("You have quit the game.");
        Application.Quit();
    }
}
