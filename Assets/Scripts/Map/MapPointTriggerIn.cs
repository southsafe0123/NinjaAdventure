using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointTriggerIn : MonoBehaviour
{
    public static bool triggerPlayerIn;
    public List<Transform> monsters = new List<Transform>();
    public GameObject wall1;
    public GameObject wall2;
    public GameObject fightZone;
    public static Vector3 _lockCam;

    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerPlayerIn = true;
            wall1.SetActive(true);
            wall2.SetActive(true);
            _lockCam = new Vector3(0, -8.69f, -10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !monsters.Contains(collision.transform))
        {
            monsters.Add(collision.transform);
        }

        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i] != null) continue;

            if (monsters[i] == null)
            {
                monsters.RemoveAt(i);
                break;
            }
        }

        if (monsters.Count == 0)
        {
            triggerPlayerIn = false;
            fightZone.SetActive(false);
        }

    }
}
