using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;

    /**
     * Open Pause Menu
     */
    public void OnMenuClick()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
}
