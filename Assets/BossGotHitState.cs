using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGotHitState : StateMachineBehaviour
{
    Rigidbody2D rb;
    BossHealth bossHealth;
    float timer;
    float healthTemp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        bossHealth = animator.gameObject.GetComponent<BossHealth>();
        healthTemp = bossHealth.health;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        timer += Time.deltaTime;
        if (timer > stateInfo.length)
        {
            animator.SetTrigger("gothit-follow");
        }
        if(bossHealth.health != healthTemp)
        {
            animator.Play("Boss_GotHitState");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        animator.ResetTrigger("gothit-follow");
    }


}
