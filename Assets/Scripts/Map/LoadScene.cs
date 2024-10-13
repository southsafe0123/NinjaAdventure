using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class LoadScene : MonoBehaviour
{
    public Animator anim;
    public float loadTime = 3f;
    public int scenePlayerIn;

    public static bool isAlreadyRegisterEvent = false;
    // Update is called once per frame
    void Start()
    {

        if (isAlreadyRegisterEvent) return;
        isAlreadyRegisterEvent = true;
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        foreach (AudioSource audio in GameSystem.MusicSystem.audioMusics)
        {
            if (audio.gameObject.activeInHierarchy)
            {
                GameSystem.MusicSystem.AudioFade(audio.gameObject.name, GameSystem.MusicSystem.musicVolume, 1f);
            }
        }
        anim.Play("LoadScene_End");
        GameSystem.GameOver.SetIsPopupGameover(false);
        GameSystem.PauseSystem.isPause = false;

        if(arg1.buildIndex == 0)
        {
            GameSystem.PauseSystem.DisplayPauseButton(false);
        }
        else
        {
            GameSystem.PauseSystem.DisplayPauseButton(true);
        }
    }


    public void loadNextScene()
    {
        gameObject.GetComponent<UpdateDataAccount>().FetchData();
        gameObject.GetComponent<UpdateDataAccount>().Logout();
        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void PlayAgain()
    {
        PlayerSave.isPlayerReset = true;
        StartCoroutine(loadScene(5));
    }
    public void LoadSceneNum(int num)
    {
        StartCoroutine(loadScene(num));
    }
    IEnumerator loadScene(int sceneNum)
    {
        if (sceneNum != 5 && sceneNum != 0)
        {
            scenePlayerIn = sceneNum;
        }

        foreach (AudioSource audio in GameSystem.MusicSystem.audioMusics)
        {
            if (audio.gameObject.activeInHierarchy)
            {
                GameSystem.MusicSystem.AudioFade(audio.gameObject.name, 0, 1f);
            }
        }
        anim.SetTrigger("Start");
        var dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSecondsRealtime(dur);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(loadTime);
        SceneManager.LoadSceneAsync(sceneNum);

    }
    public void loadMenu()
    {
        StartCoroutine(loadScene(0));
    }

    public void ClickQuitGame()
    {
        StartCoroutine(QuitGame());
    }

    private IEnumerator QuitGame()
    {
        anim.SetTrigger("Start");
        var dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSecondsRealtime(dur);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(loadTime);
        Application.Quit();
    }
}
