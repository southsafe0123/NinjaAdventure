using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PlayerSave.instance.addShuriken();
        deActiveObj();
    }
    public void ChooseShuriDmg()
    {
        PlayerSave.instance.addDamage();
        deActiveObj();
    }
    public void ChooseHealthPlus()
    {
        PlayerSave.instance.addHealth();
        deActiveObj();
    }

    private void deActiveObj()
    {
        Time.timeScale = 1f;
        objChooseSkill.SetActive(false);
        PlayerStatus.UpdateCheckLevel();
    }
}
