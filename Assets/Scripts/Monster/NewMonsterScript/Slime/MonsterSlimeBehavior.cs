using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlimeBehavior : MonoBehaviour
{
    public const string IDLE_STATE = "isIdle";
    public const string WANDER_STATE = "isWander";
    public const string HOLDINGCHASE_STATE = "isHoldingChase";
    public const string CHASE_STATE = "isChasing";

    public float delayBetweenState;
}
