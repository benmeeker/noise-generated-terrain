using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {        
        SceneManager.LoadScene("Game");
        Manager.Instance.com.join();
    }

    public void QuitGame()
    {
        Application.Quit();
        Manager.Instance.com.quit();
    }
}
