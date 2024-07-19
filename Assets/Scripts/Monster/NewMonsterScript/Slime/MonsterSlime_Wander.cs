using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MonsterSlime_Wander: StateMachineBehaviour
{
    MonsterSlimeBehavior slimeBehavior;
    Transform moveArea;
    int randomState;
    Vector2 randomMoveArea;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomState = 0;
        slimeBehavior = animator.GetComponent<MonsterSlimeBehavior>();
        animator.SetBool(MonsterSlimeBehavior.WANDER_STATE, true);
        moveArea = animator.transform.parent;
        slimeBehavior.StartCoroutine(WaitNextState_Coroutine(animator));
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( randomMoveArea.x != 0 && randomMoveArea.y != 0)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, randomMoveArea, animator.GetComponent<MonsterBase>().moveSpeed * Time.deltaTime);
            if (Vector3.Distance(animator.transform.position, randomMoveArea) < 0.01f)
            {
                randomMoveArea = Vector2.zero;
            }
        }
        
    }
    IEnumerator WaitNextState_Coroutine(Animator animator)
    {
        Debug.Log("in");
        randomMoveArea = new Vector2(moveArea.position.x + Random.Range(-7, 8), moveArea.position.y + Random.Range(4, -5));
        Debug.Log(animator.transform.position + "/" + randomMoveArea);
        yield return new WaitUntil(()=> randomMoveArea == Vector2.zero);
        randomState = 0;
        switch (randomState)
        {
            case 0:
                animator.SetBool(MonsterSlimeBehavior.IDLE_STATE, true);
                animator.SetBool(MonsterSlimeBehavior.WANDER_STATE, false);
                break;
            case 1:
                animator.SetBool(MonsterSlimeBehavior.HOLDINGCHASE_STATE, true);
                animator.SetBool(MonsterSlimeBehavior.WANDER_STATE, false);
                break;
        }
    }
}