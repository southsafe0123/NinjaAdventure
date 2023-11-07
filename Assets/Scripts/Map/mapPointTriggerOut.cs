using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPointTriggerOut : MonoBehaviour
{
    public static bool triggerPlayerOut;
    public GameObject wall1;
    public GameObject wall2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerPlayerOut = true;
            wall1.SetActive(false);
            wall2.SetActive(false);
        }
    }
}
