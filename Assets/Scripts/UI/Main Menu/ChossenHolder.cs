using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChossenHolder : MonoBehaviour
{
    public GameObject flag;
    public Text text;

    public void DisplayChossen()
    {
        if (flag != null)
        {
            flag.SetActive(true);
        }

        text.color = Color.white;
    }
    public void UnDisplayChossen()
    {
        if (flag != null)
        {
            flag.SetActive(false);
        }
        
        text.color = Color.black;
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
   
    public void Resume()
    {
        transform.parent.parent.GetComponent<PauseMenu>().TogglePause();
    }

    public void pointerEnterStopPlayerShoot()
    {
        GameObject.Find("player").transform.GetChild(0).gameObject.SetActive(false);
    }

    public void pointerExitStopPlayerShoot()
    {
        GameObject.Find("player").transform.GetChild(0).gameObject.SetActive(true);
    }
}
