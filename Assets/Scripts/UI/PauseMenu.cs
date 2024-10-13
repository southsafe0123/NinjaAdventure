using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPause;
    public GameObject pauseMenu;
    public GameObject pauseButtonObject;
    public bool isPauseClick;
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            DisplayPauseButton(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) return;
            if (SceneManager.GetActiveScene().buildIndex == 4) return;
            TogglePause();
        }
       
    }

    public void ShowMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisplayPauseButton(bool isActive)
    {
        pauseButtonObject.SetActive(isActive);
    }

    public void HideMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void isClicked()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPause = !isPause;

        if (isPause)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }

    }
}
