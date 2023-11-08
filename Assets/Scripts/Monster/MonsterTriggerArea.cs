using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTriggerArea : MonoBehaviour
{
    public bool isPlayerInZone;
    public Transform playerTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //kich hoat quai vat
            isPlayerInZone = true;
            playerTransform = collision.gameObject.transform;
            Debug.Log(playerTransform);
        }
    }
}
