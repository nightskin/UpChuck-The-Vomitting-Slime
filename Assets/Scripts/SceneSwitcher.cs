using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
