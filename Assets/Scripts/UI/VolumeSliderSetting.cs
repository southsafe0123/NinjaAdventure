using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSetting : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.value = GameSystem.MusicSystem.musicVolume;
    }
    public void OnValueChange()
    {
        GameSystem.MusicSystem.SetMusicVolume(slider.value);
    }
}
