using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public const string BACKGROUND_MUSIC = "BackgroundMusic";
    public const string BOSS_MUSIC = "BossMusic";
    public const string DIE_MUSIC = "DieMusic";
    public const string HOVER_SOUND = "hover";
    public const string CLICK_SOUND = "clik";

    public List<AudioSource> audioSounds = new List<AudioSource>();
    public List<AudioSource> audioMusics = new List<AudioSource>();
    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }

    public void SetMusicVolume(float musicVolume)
    {
        var audioSourceBGMusic = GetAudioSource(MusicManager.BACKGROUND_MUSIC);
        var audioSourceBossMusic = GetAudioSource(MusicManager.BOSS_MUSIC);
        var audioSourceDieMusic = GetAudioSource(MusicManager.DIE_MUSIC);
        audioSourceBGMusic.volume = musicVolume;
        audioSourceBossMusic.volume = musicVolume;
        audioSourceDieMusic.volume = musicVolume;
    }
    public AudioSource GetAudioSource(string audioName)
    {
        try
        {
            var audioSound = audioSounds.First(audio => audio.gameObject.name.Equals(audioName));
            return audioSound;
        }
        catch
        {
            try
            {
                var audioMusic = audioMusics.First(audio => audio.gameObject.name.Equals(audioName));
                return audioMusic;
            }
            catch
            {
                return null;
            }

        }

    }
    public void AudioFade(string audioName, float endValue, float dtwSpeed, Action OnComplete = null)
    {
        var audio = GetAudioSource(audioName);
        audio.DOFade(endValue, dtwSpeed).OnComplete(() =>
        {
            OnComplete?.Invoke();
        });
    }

    public void SetAudioClipForAudioSource(string audioName, int bgMusicID)
    {
        var audio = GetAudioSource(audioName);
        audio.clip = audioClips[bgMusicID];
    }
}