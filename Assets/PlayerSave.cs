using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
    public static PlayerSave instance;
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
    }


    public static void ResetStat()
    {
        playerShooting.ShurikenPLayerHave = 1;
        PlayerHealth.PlayerMaxHeath = 2;
        PlayerHealth.PlayerCurrentHealth = 2;
        shurikenBullet.s_shurikenDamage = 1;
        PlayerStatus.s_Exp = 0;
        PlayerStatus.s_expRequire = 4;
        PlayerStatus.s_level = 0;
        PlayerStatus.s_oldLevel = 0;
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
