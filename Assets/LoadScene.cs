﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class LoadScene : MonoBehaviour
{
    public Animator anim;
    public float loadTime = 3f;
    public static int scenePlayerIn;
    // Update is called once per frame
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadNextScene();
        }
    }
    public void loadNextScene()
    {
        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void PlayAgain()
    {
        PlayerSave.ResetStat();
        scenePlayerIn = 1;
        StartCoroutine(loadScene(4));
    }

    IEnumerator loadScene(int sceneNum)
    {
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
}
