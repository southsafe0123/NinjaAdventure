using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameoverPanel;
    private bool isPopupGameover = false;
    private void Update()
    {
        if (PlayerHealth.PlayerCurrentHealth <= 0 && !isPopupGameover)
        {
            SetIsPopupGameover(true);
            gameoverPanel.SetActive(true);
            GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC).Stop();
            GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.DIE_MUSIC).Play();

        }
    }
    public void SetIsPopupGameover(bool isActive)
    {
        isPopupGameover = isActive;
    }
}