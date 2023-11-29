using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCooldownState : StateMachineBehaviour
{
    BossBehavior bossBehavior;
    BossHealth bossHealth;
    float timer;
    float healthTemp;
    bool isChangeState;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior = animator.gameObject.GetComponent<BossBehavior>();
        bossHealth = animator.gameObject.GetComponent<BossHealth>();    
        isChangeState = false;
        timer = 0;

        bossHealth.isInCooldownState = true;
        healthTemp = bossHealth.health;
        bossBehavior.inCDState = true;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer += Time.deltaTime;
        if (timer > bossBehavior.timeCooldown)
        {
            isChangeState = true;
        }
        if (isChangeState)
        {
            animator.SetTrigger("cooldown-follow");
        }
        if (bossHealth.isInCooldownState)
        {
            if (bossHealth.health != healthTemp)
            {
                animator.SetTrigger("cooldown-gothit");
            }
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("cooldown-follow");
        animator.ResetTrigger("cooldown-gothit");
        timer = 0;
        isChangeState = false;
        bossBehavior.inCDState = false;
    }
}
