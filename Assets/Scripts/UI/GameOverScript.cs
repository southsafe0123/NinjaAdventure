using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameoverPanel;
    public bool isPopupGameover = false;
    private void Update()
    {
        if (PlayerHealth.PlayerCurrentHealth <= 0 && !isPopupGameover)
        {
            isPopupGameover = true;
            gameoverPanel.SetActive(true);
            MusicManager.Instance.GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC).Stop();
            MusicManager.Instance.GetAudioSource(MusicManagerAudioName.DIE_MUSIC).Play();

        }
    }
}