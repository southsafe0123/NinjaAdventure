using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowState : StateMachineBehaviour
{
    Rigidbody2D rb;
    BossBehavior bossBehavior;
    BossHealth bossHealth;
    float timer;
    bool isGoNextState;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        bossBehavior = animator.gameObject.GetComponent<BossBehavior>();
        bossHealth = animator.gameObject.GetComponent<BossHealth>();
        isGoNextState = false;

        bossHealth.isInCooldownState = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer += Time.deltaTime;
        if(timer > bossBehavior.timeFollow)
        {
            isGoNextState = true;
           
        }
        if (!isGoNextState)
        {
            MoveToPlayer(animator);
        }
        else
        {
            animator.SetTrigger("follow-dash");
            rb.velocity = Vector2.zero;
        }

        
    }

    private void MoveToPlayer(Animator animator)
    {
        var playerPos = bossBehavior.trigger.player.transform.position;
        var bossPos = animator.gameObject.transform.position;
        Vector2 dir = playerPos - bossPos;
        rb.velocity = dir.normalized * bossBehavior.moveSpeed;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("follow-dash");
        timer = 0;
        isGoNextState = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
