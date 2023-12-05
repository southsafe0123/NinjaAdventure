using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPause;
    public GameObject pauseMenu;
    public bool isPauseClick;
    private GameObject musicManager;
    private void Start()
    {
        musicManager = GameObject.Find("MusicManager");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void ShowMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
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
