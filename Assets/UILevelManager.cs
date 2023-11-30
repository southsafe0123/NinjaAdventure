using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        float level = PlayerStatus.s_level + 1;
        text.SetText("Lv."+level);
    }
}
