using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointTriggerIn2 : MonoBehaviour
{
    public static bool triggerPlayerIn;
    public List<Transform> monsters = new List<Transform>();
    public GameObject wall1;
    public GameObject wall2;
    public GameObject fightZone;
    public static Vector3 _lockCam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerPlayerIn = true;
            wall1.SetActive(true);
            wall2.SetActive(true);
            _lockCam = new Vector3(0, -17.68f, -10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !monsters.Contains(collision.transform))
        {
            monsters.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            monsters.Remove(collision.transform);
            if (monsters.Count == 0)
            {
                triggerPlayerIn = false;
                fightZone.SetActive(false);
            }
        }
    }
}
