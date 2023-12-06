using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Scene;
    public int healthMax;
    public int currentHealth;
    public int shurikenDmg;
    public int shirukenNum;
    public int currentExp;
    public int level;
    public int expRequire;

    public PlayerData(int scene, int healthMax, int currentHealth, int shurikenDmg, int shirukenNum, int currentExp, int level, int expRequire)
    {
        Scene = scene;
        this.healthMax = healthMax;
        this.currentHealth = currentHealth;
        this.shurikenDmg = shurikenDmg;
        this.shirukenNum = shirukenNum;
        this.currentExp = currentExp;
        this.level = level;
        this.expRequire = expRequire;
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
