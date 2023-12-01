using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth;
    [Header("dont need to set health")]
    public float health;
    public GameObject prefExp;
    public bool isInCooldownState;
    public float numOfExp;
    public GameObject bossUI;

    private void Start()
    {
        health = maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken") && isInCooldownState)
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
        }
    }
    private void Update()
    {
    }
    public void die()
    {
        bossUI.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public IEnumerator spawnEXP()
    {
        int i=0;
        while (i<numOfExp)
        {
            GameObject obj = Instantiate(prefExp,transform.position,Quaternion.identity) as GameObject;
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void GetDamage(float damage)
    {
        health -= damage;
    }
}
