using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public static string id;
    public float scene;
    public float health;
    public float maxhealth;
    public float shurikenDmg;
    public float shurikenNum;
    public float level;
    public float exp;
    public float expRequire;

    public void setData()
    {
        scene = LoadScene.scenePlayerIn;
        health = PlayerHealth.PlayerCurrentHealth;
        maxhealth = PlayerHealth.PlayerMaxHeath;
        shurikenNum = playerShooting.ShurikenPLayerHave;
        shurikenDmg = shurikenBullet.s_shurikenDamage;
        level = PlayerStatus.s_level;
        exp = PlayerStatus.s_Exp;
        expRequire = PlayerStatus.s_expRequire;
    }

    public void getData()
    {
        LoadScene.scenePlayerIn = (int)scene;
        PlayerHealth.PlayerCurrentHealth = health;
        PlayerHealth.PlayerMaxHeath = maxhealth;
        playerShooting.ShurikenPLayerHave = shurikenNum;
        shurikenBullet.s_shurikenDamage = shurikenDmg;
        PlayerStatus.s_level = level;
        PlayerStatus.s_Exp = exp;
        PlayerStatus.s_expRequire = expRequire;
    }
    //public string _id;
    //public string name;
    //public string password;
    //public int healthMax;
    //public int currentHealth;
    //public int shurikenDmg;
    //public int shirukenNum;
    //public int currentExp;
    //public int level;
    //public int expRequire;
    //public int scene;
}
