using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatManager : MonoBehaviour
{
    public GameObject objChooseSkill;
    private void Update()
    {
        if (PlayerStatus.IsLevelUp())
        {
            Time.timeScale = 0f;
            objChooseSkill.SetActive(true);
        }
    }

    public void ChooseShuriPlus()
    {
        PlayerShooting.ShurikenPLayerHave++;
        deActiveObj();
    }
    public void ChooseShuriDmg()
    {
        MonsterHealth.s_shurikenDamage++;
        deActiveObj();
    }
    public void ChooseHealthPlus()
    {
        PlayerHealth.PlayerMaxHeath++;
        deActiveObj();
    }

    private void deActiveObj()
    {
        Time.timeScale = 1f;
        objChooseSkill.SetActive(false);
        PlayerStatus.UpdateCheckLevel();
    }
}
