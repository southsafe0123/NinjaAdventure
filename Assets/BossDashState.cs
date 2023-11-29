using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDashState : StateMachineBehaviour
{
    Rigidbody2D rb;
    BossBehavior bossBehavior;
    float timer;
    bool isStartDash;
    private Vector3 playerPos;
    private Vector3 bossPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        bossBehavior = animator.gameObject.GetComponent<BossBehavior>();
        isStartDash = false;
        timer = 0;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > bossBehavior.timeChargeDash)
        {
            isStartDash = true;
            
        }
        if (isStartDash)
        {
            isStartDash = false;
            animator.SetTrigger("dash-cooldown");
        }
        else
        {
            bossBehavior.dangerLine.enabled = true;
            bossPos = animator.gameObject.transform.position;
            playerPos = bossBehavior.trigger.player.position;
            var dir = playerPos - bossPos;

            bossBehavior.dangerLine.SetPosition(0, bossPos);
            bossBehavior.dangerLine.SetPosition(1, dir.normalized*100);
        }
    }
    private void Dash(Animator animator)
    {
       
        Vector2 dir = playerPos - bossPos;
        rb.velocity = dir.normalized * bossBehavior.moveSpeed*4;
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior.dangerLine.SetPosition(1, bossPos);
        bossBehavior.dangerLine.SetPosition(0, bossPos);
        Dash(animator);
        animator.ResetTrigger("dash-cooldown");
        timer = 0;
        bossBehavior.dangerLine.enabled = false;
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
