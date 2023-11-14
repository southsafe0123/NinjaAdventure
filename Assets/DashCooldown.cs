using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    public Slider slider;
    public GameObject dashBar;
    public PlayerMovement player;
    private void Start()
    {
    }
    private void Update()
    {
        if(player.timer==0)
        {
            dashBar.SetActive(false);
        }
        else
        {
            dashBar.SetActive(true);
            slider.value = player.timer / player.dashCooldown;
        }
        
    }
}
