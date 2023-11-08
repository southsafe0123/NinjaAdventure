using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public Vector2 DirectionToPlayer { get; private set; }
    public MonsterTriggerArea area;
    public MonsterRandomMovement randomMovement;

    public float speedMonster;

    private void Update()
    {
        if (area.isPlayerInZone)
        {
            //TODO cho quai vat di chuyen den nguoi choi
            Vector2 enemyToPlayerVector = area.playerTransform.position - transform.position;
            DirectionToPlayer = enemyToPlayerVector.normalized;
            transform.position += (Vector3) DirectionToPlayer*Time.deltaTime * speedMonster;
        }
    }
}
