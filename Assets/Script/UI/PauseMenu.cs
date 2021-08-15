using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePased = false;
    public GameObject menuUI;

    private void Start()
    {
        isGamePased = false;
        menuUI.SetActive(false);
    }
    public void OnShowMenu()
    {    
        if (isGamePased)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        isGamePased = true;
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        isGamePased = false;
        menuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
