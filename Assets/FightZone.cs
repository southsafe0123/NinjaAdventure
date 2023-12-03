using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public List<Transform> monsters = new List<Transform>();
    public GameObject wall1;
    public GameObject wall2;
    public Collider2D playerCol;

    public VerticalCamera cameraScript;

    void Start()
    {
        cameraScript = GameObject.Find("Main Camera").GetComponent<VerticalCamera>();
    }

    private void Update()
    {
        if(playerCol != null)
        {
            if (monsters.Count == 0)
            {
                monsters.Clear();
                wall1.SetActive(false);
                wall2.SetActive(false);
                cameraScript.playerTarget = playerCol.gameObject;
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCol = collision;
            wall1.SetActive(true);
            wall2.SetActive(true);
            cameraScript.playerTarget = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraScript.playerTarget = collision.gameObject;
        }
        if (collision.CompareTag("enemy"))
        {
            monsters.Remove(collision.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") && !monsters.Contains(collision.transform))
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
    }
}
