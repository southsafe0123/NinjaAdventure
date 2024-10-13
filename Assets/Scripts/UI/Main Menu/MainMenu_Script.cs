using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{

    private void Start()
    {

        playerShooting.ShurikenPLayerHave = PlayerSave.defaultShurikenPlayerHave;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 0);
                break;
            case 1:
                GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 1);
                break;
            case 2:
                GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 2);
                break;
            case 3:
                GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 3);
                break;
            case 4:
                GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 4);
                break;
        }
        GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC).Play();
    }
}
