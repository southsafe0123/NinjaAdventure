using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void addShuriken()
    {
        PlayerShooting.ShurikenPLayerHave++;
    }

    public void addHealth()
    {
        PlayerHealth.PlayerCurrentHealth++;
        PlayerHealth.PlayerMaxHeath++;
    }

    public void addDamage()
    {
        MonsterHealth.s_shurikenDamage++;
    }
}
