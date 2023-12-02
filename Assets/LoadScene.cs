using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class LoadScene : MonoBehaviour
{
    public Animator anim;
    public float loadTime = 3f;
    public int loadscene;
    // Update is called once per frame
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadNextScene(loadscene);
        }
    }

    public void loadNextScene(int loadscene)
    {
        StartCoroutine(loadScene(loadscene));
        Debug.Log("Bắt đầu màn " + (loadscene));
    }

    public void PlayAgain(int reloadscene)
    {
        PlayerHealth.PlayerCurrentHealth = PlayerHealth.PlayerMaxHeath;
        playerShooting.ShurikenPLayerHave = 1;
        StartCoroutine(loadScene(reloadscene));
        Time.timeScale = 1;
    }

    IEnumerator loadScene(int sceneNum)
    {
        anim.SetTrigger("Start");
        var dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(dur + loadTime);
        SceneManager.LoadScene(sceneNum);
    }
    public void loadMenu()
    {
        StartCoroutine(loadScene(0));
        Time.timeScale = 1;
    }
}
