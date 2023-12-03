using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoadScene : MonoBehaviour
{
    public Animator loadSceneAnim;
    private void Start()
    {
        loadSceneAnim.Play("LoadScene_Player");
        SceneManager.LoadSceneAsync(LoadScene.scenePlayerIn);
    }

}
