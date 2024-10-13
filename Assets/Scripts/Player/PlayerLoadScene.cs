using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoadScene : MonoBehaviour
{
    public Animator loadSceneAnim;
    private void Start()
    {
        if (PlayerSave.isPlayerReset)
        {
            PlayerSave.ResetStat();
        }

        loadSceneAnim.Play("LoadScene_Player");
        SceneManager.LoadSceneAsync(GameSystem.LoadScene.scenePlayerIn);
    }

}
