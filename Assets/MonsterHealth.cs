using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float health;
    public MonsterBehavior monster;
    public GameObject prefExp;
    private bool lockDead;

    private void Start()
    {
        monster = GetComponent<MonsterBehavior>();
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
        if (health <= 0&&!lockDead)
        {
            lockDead = true;
            Instantiate(prefExp,transform.position, Quaternion.identity);
            Destroy(gameObject, monster.knockBackDuration);
            
        }
    }
    
    void GetDamage(float damage)
    {

        health -= damage;
    }
}
