using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderSetting : MonoBehaviour
{
    public Slider slider;
    public bool isFirstLoad = true;
    private void Start()
    {
        isFirstLoad = true;
        slider.value = GameSystem.MusicSystem.soundVolume;
    }
    public void OnValueChange()
    {

        GameSystem.MusicSystem.SetSFXVolume(slider.value);
        if (GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).isPlaying) return;
        if (isFirstLoad)
        {
            isFirstLoad = false;
        }
        else
        {
            GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).Play();

        }
    }
}
