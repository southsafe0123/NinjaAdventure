using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
    public static PlayerSave instance;
    public static bool isNewPlay;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        Application.targetFrameRate = 60;

        PlayerLoadData();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            //tiến hành lưu nhân vật ở đây trước khi về menu;
            Destroy(gameObject);
        }
    }
    private void PlayerLoadData()
    {
        if (isNewPlay)
        {
            playerShooting.ShurikenPLayerHave = 1;
            PlayerHealth.PlayerCurrentHealth = 2;
            PlayerHealth.PlayerMaxHeath=2;
            shurikenBullet.s_shurikenDamage=1;
        }
        else
        {
            //take data from api
        }
    }

    public void addShuriken()
    {
        playerShooting.ShurikenPLayerHave++;
    }

    public void addHealth()
    {
        PlayerHealth.PlayerCurrentHealth++;
        PlayerHealth.PlayerMaxHeath++;
    }

    public void addDamage()
    {
        shurikenBullet.s_shurikenDamage++;
    }
}
