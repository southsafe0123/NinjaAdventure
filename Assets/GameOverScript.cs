using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private int manchoi;
    public void PlayAgain(int manchoi)
    {
        SceneManager.LoadSceneAsync(manchoi); 
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

   
}
