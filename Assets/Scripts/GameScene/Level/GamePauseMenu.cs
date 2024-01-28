using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseMenu : MonoBehaviour
{
    public GameObject menu;
    
    /**
     * Open Pause Menu
     */
    public void OnResumeClick()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    /**
     * Restart Game
     */
    public void OnRestartClick()
    {
        SceneManager.LoadScene("NewGame3DScene");
    }

    /**
     * Exit Game
     */
    public void OnExitClick()
    {
        Application.Quit();
    }
}
