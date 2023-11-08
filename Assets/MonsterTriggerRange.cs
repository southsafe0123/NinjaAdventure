using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTriggerRange : MonoBehaviour
{
    public bool isPlayerInZone;
    public Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInZone = true;
            player = collision.transform;
        }
    }
}
