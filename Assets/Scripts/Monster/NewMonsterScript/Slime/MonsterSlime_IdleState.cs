using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MonsterSlime_IdleState : StateMachineBehaviour
{
    MonsterSlimeBehavior slimeBehavior;
    int randomState;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomState = 0;
        slimeBehavior = animator.GetComponent<MonsterSlimeBehavior>();
        animator.SetBool(MonsterSlimeBehavior.IDLE_STATE, true);
        slimeBehavior.StartCoroutine(WaitNextState_Coroutine(animator));
    }

    IEnumerator WaitNextState_Coroutine(Animator animator)
    {
        yield return new WaitUntil(()=>animator.GetComponent<MonsterBase>().triggerRange.player != null);
        yield return new WaitForSecondsRealtime(slimeBehavior.delayBetweenState);
        randomState = 0;
        switch (randomState)
        {
            case 0:
                animator.SetBool(MonsterSlimeBehavior.IDLE_STATE, false);
                animator.SetBool(MonsterSlimeBehavior.WANDER_STATE, true);
                break;
            case 1:
                animator.SetBool(MonsterSlimeBehavior.IDLE_STATE, false);
                animator.SetBool(MonsterSlimeBehavior.HOLDINGCHASE_STATE, true);
                break;
        }
    }
}
