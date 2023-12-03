using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameoverPanel;
    private void Update()
    {
        if (PlayerHealth.PlayerCurrentHealth <= 0)
        {
            gameoverPanel.SetActive(true);
        }
    }
}
