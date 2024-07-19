using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerState : StateMachineBehaviour
{
    GameObject bossUI;
    GameObject musicManager;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossUI = GameObject.Find("BossUI");
        musicManager = GameObject.Find("MusicManager");

        bossUI.transform.GetChild(0).gameObject.SetActive(true);
        MusicManager.Instance.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 6);
        MusicManager.Instance.GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC).Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            animator.SetTrigger("trigger-follow");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
