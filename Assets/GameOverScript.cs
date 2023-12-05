using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameoverPanel;
    private GameObject musicManager;
    private void Start()
    {
        musicManager = GameObject.Find("MusicManager");
    }
    private void Update()
    {
        if (PlayerHealth.PlayerCurrentHealth <= 0)
        {
            gameoverPanel.SetActive(true);
            if(musicManager != null)
            {
                
                foreach (Transform children in musicManager.transform)
                {
                    children.gameObject.SetActive(false);
                    if (children.gameObject.name.Equals("DieMusic"))
                    {
                        children.gameObject.SetActive(true);
                    }
                   
                }
                musicManager = null;
            }
        }
    }
}
