using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }
}
