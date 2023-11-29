using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthSlider : MonoBehaviour
{
    public Animator animator;
    public BossHealth bossHealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            slider.value = bossHealth.health/bossHealth.maxHealth;
            animator.enabled = false;
        }
    }
}
