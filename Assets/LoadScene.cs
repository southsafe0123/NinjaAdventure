using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator anim;
    public float loadTime = 3f;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loadNextScene();
        }
    }

    void loadNextScene( )
    {
        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadScene(int sceneNum)
    {
        anim.SetTrigger("Start");
        var dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        yield return new WaitForSeconds(dur + loadTime);
        SceneManager.LoadScene(sceneNum);
    }
}
