using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSetting : MonoBehaviour
{
    public Slider slider;
    public void OnValueChange()
    {
        MusicManager.Instance.SetMusicVolume(slider.value);
    }
}
