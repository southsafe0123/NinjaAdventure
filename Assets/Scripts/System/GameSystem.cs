using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public static MusicManager MusicSystem;
    public static PauseMenu PauseSystem;
    public static LoadScene LoadScene;
    public static GameOverScript GameOver;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        MusicSystem = GetComponentInChildren<MusicManager>();
        PauseSystem = GetComponentInChildren<PauseMenu>();
        LoadScene = GetComponentInChildren<LoadScene>();
        GameOver = GetComponentInChildren<GameOverScript>();
    }
}
