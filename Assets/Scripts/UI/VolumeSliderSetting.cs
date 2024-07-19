using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSetting : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.value = MusicManager.Instance.musicVolume;
    }
    public void OnValueChange()
    { 
        MusicManager.Instance.SetMusicVolume(slider.value);
    }
}
