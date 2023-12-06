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

    public enum ValueType
    {
        scene,
        shurikenNum,
        maxHealth,
        currentHealth,
        shurikenDmg,
        currentExp,
        maxExp,
        level
    }

    public static float GetValue(ValueType valueType)
    {
        switch (valueType)
        {
            case ValueType.scene:
                return LoadScene.scenePlayerIn;
            case ValueType.shurikenNum:
                return playerShooting.ShurikenPLayerHave;
            case ValueType.maxHealth:
                return PlayerHealth.PlayerMaxHeath;
            case ValueType.currentHealth:
                return PlayerHealth.PlayerCurrentHealth;
            case ValueType.shurikenDmg:
                return shurikenBullet.s_shurikenDamage;
            case ValueType.currentExp:
                return PlayerStatus.s_Exp;
            case ValueType.maxExp:
                return PlayerStatus.s_expRequire;
            case ValueType.level:
                return PlayerStatus.s_level;
            default:
                return 0;
        }
    }
    public static void ResetStat()
    {
        LoadScene.scenePlayerIn = 1;
        playerShooting.ShurikenPLayerHave = 1;
        PlayerHealth.PlayerMaxHeath = 2;
        PlayerHealth.PlayerCurrentHealth = 2;
        shurikenBullet.s_shurikenDamage = 1;
        PlayerStatus.s_Exp = 0;
        PlayerStatus.s_expRequire = 4;
        PlayerStatus.s_level = 0;
        PlayerStatus.s_oldLevel = 0;
    }

    public static void SetStats
        (
        float scenePlayerIn,
        float playerMaxHealth, 
        float playerCurrentHealth,
        float shurikenNum, 
        float shurikenDamage, 
        float currentExp, 
        float maxExp,
        float level
        )
    {
        LoadScene.scenePlayerIn = (int)scenePlayerIn;
        PlayerHealth.PlayerMaxHeath = playerMaxHealth;
        PlayerHealth.PlayerCurrentHealth = playerCurrentHealth;
        playerShooting.ShurikenPLayerHave = shurikenNum;
        shurikenBullet.s_shurikenDamage= shurikenDamage;
        PlayerStatus.s_Exp = currentExp;
        PlayerStatus.s_expRequire = maxExp ;
        PlayerStatus.s_level= level;
        PlayerStatus.s_oldLevel = level;
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
