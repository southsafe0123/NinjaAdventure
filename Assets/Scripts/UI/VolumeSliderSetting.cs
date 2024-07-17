using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSetting : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.value = 0.2f;
    }
    public void OnValueChange()
    { 
        MusicManager.Instance.SetMusicVolume(slider.value);
    }
}
