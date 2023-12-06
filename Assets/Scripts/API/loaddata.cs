using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Loaddata
{
    public string _id;
    public float Scene;
    public float healthMax;
    public float currentHealth;
    public float shurikenDmg;
    public float shirukenNum;
    public float currentExp;
    public float level;
    public float expRequire;

    public Loaddata(string id, float scene, float healthMax, float currentHealth, float shurikenDmg, float shirukenNum, float currentExp, float level, float expRequire)
    {
        _id = id;
        Scene = scene;
        this.healthMax = healthMax;
        this.currentHealth = currentHealth;
        this.shurikenDmg = shurikenDmg;
        this.shirukenNum = shirukenNum;
        this.currentExp = currentExp;
        this.level = level;
        this.expRequire = expRequire;
    }
}
