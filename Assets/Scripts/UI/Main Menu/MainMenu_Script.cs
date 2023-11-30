using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    private bool isPause = false;
    public GameObject Menu;
    public GameObject Gameover;

    private void Start()
    {
        PlayerHealth.PlayerCurrentHealth = 2;
        Gameover.SetActive(false);
        Time.timeScale = 1; 
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame()
    {
        Debug.Log("Đã thoát");
        Application.Quit();
    }

    public void Continue()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;

            if(isPause)
            {
                ShowMenu();
            }
            else
            {
                HideMenu();
            }
        }

        DisplayGameOver();
    }

    void ShowMenu()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }

    void HideMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void DisplayGameOver()
    {
        if (PlayerHealth.PlayerCurrentHealth == 0)
        {
            Gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
