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
    private void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            DisplayPauseButton(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
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
