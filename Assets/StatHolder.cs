using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatHolder : MonoBehaviour
{
    public Stat stat;
    public TextMeshProUGUI statName;
    public TextMeshProUGUI statDetail;

    public void DisplayStat()
    {
        statName.SetText(stat.name);
        statDetail.SetText(stat.detail);
    }
    public void UnDisplayStat()
    {
        statName.SetText("");
        statDetail.SetText("");
    }
}
