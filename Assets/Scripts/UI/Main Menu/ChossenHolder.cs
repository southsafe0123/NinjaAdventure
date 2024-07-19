using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChossenHolder : MonoBehaviour
{
    public GameObject flag;
    public Text text;
    public Image color;
    public void DisplayChossen()
    {
        if (flag != null)
        {
            flag.SetActive(true);
        }

        text.color = Color.white;

        MusicManager.Instance.GetAudioSource(MusicManagerAudioName.HOVER_SOUND).Play();
    }
    public void UnDisplayChossen()
    {
        if (flag != null)
        {
            flag.SetActive(false);
        }
        
        text.color = Color.black;
    }

    public void OnPointerClick()
    {
        MusicManager.Instance.GetAudioSource(MusicManagerAudioName.CLICK_SOUND).Play();
    }

    public void DisplayChossenAlert()
    {
        if (flag != null)
        {
            flag.SetActive(true);
        }

        text.color = Color.white;
    }
    public void UnDisplayChossenAlert()
    {
        if (flag != null)
        {
            flag.SetActive(false);
        }

        text.color = Color.red;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
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
