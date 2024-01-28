using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /**
     * Open Start Scene
     */
    public void OnStartClick()
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
