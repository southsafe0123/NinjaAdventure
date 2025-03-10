﻿using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public static class MusicManagerAudioName
{
    public const string BACKGROUND_MUSIC = "BackgroundMusic";
    public const string BOSS_MUSIC = "BossMusic";
    public const string DIE_MUSIC = "DieMusic";
    public const string HOVER_SOUND = "hover";
    public const string CLICK_SOUND = "clik";
    public const string PLAYER_GOT_HIT_SOUND = "playerGotHit";
    public const string PLAYER_GOT_EXP_SOUND = "playerGotExp";
    public const string SHURIKEN_WALL_HIT_SOUND = "ShurikenWallHit";
    public const string SHURIKEN_ENEMY_HIT_SOUND = "ShurikenEnemyHit";
    public const string FROG_HIT_WALL_SOUND = "FrogHitWall";
    public const string ALERT_SHURIKEN_GO_BACK_SOUND = "AlertShurikenGoBack";
    public const string DASH_SOUND = "Dash";
}

public class MusicManager : MonoBehaviour
{
    public float musicVolume;
    public float soundVolume;

    public List<AudioSource> audioSounds = new List<AudioSource>();
    public List<AudioSource> audioMusics = new List<AudioSource>();
    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Awake()
    {
            SetMusicVolume(musicVolume);
            SetSFXVolume(soundVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        this.musicVolume = musicVolume;
        var audioSourceBGMusic = GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC);
        audioSourceBGMusic.volume = musicVolume;
    }
    public void SetSFXVolume(float soundVolume)
    {
        this.soundVolume = soundVolume;
        foreach (AudioSource audio in audioSounds)
        {
            audio.volume = soundVolume;
        }
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