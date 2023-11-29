using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIExpManager : MonoBehaviour
{

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.SetText(PlayerStatus.s_Exp+"/"+PlayerStatus.s_expRequire);
    }
}
