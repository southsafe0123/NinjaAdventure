using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGhostHealth : MonoBehaviour
{
    public int health;
    public MatroiMovement monster;
    public GameObject prefExp;
    private bool lockDead;

    private void Start()
    {
        monster = GetComponent<MatroiMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
        }
    }
    private void Update()
    {
        if (health <= 0 && !lockDead)
        {
            lockDead = true;
            DropExp();
            Die();
        }
    }

    void GetDamage(float damage)
    {

        health -= (int)damage;
    }

    private void Die()
    {
        Debug.Log("Monster is dead!");

        // Ti?p t?c x? lý khi slime ch?t
        Destroy(gameObject, monster.knockBackDuration);
    }

    private void DropExp()
    {
        if (prefExp != null)
        {
            Instantiate(prefExp, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("prefExp is not assigned!");
        }
    }
}
