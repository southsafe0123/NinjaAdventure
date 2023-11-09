using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float health;
    public MonsterBehavior monster;

    private void Start()
    {
        monster = GetComponent<MonsterBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            health--;
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(deadState());
        }
    }

    IEnumerator deadState()
    {
        yield return null;
        Destroy(gameObject,monster.knockBackDuration);
    }
}
