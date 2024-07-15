using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExpCheckPlayer : MonoBehaviour
{
    public Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }
}
