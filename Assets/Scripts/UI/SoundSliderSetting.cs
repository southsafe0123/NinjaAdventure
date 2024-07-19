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
        slider.value = MusicManager.Instance.soundVolume;
    }
    public void OnValueChange()
    {

        MusicManager.Instance.SetSFXVolume(slider.value);
        if (MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).isPlaying) return;
        if (isFirstLoad)
        {
            isFirstLoad = false;
        }
        else
        {
            MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).Play();

        }
    }
}
