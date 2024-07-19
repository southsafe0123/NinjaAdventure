using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public abstract class MonsterBase : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public float knockBackForce;
    public float knockBackDuration;
    public float hitLagDur;
    public float hitLagWait;

    public MonsterTriggerRange triggerRange;
    public GameObject hiteffect;
    public GameObject prefExp;
     
    private bool gotHit;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void GetDamage(float damage)
    {

        health -= (int)damage;
        if (health <= 0)
        {
            DropExp();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
            StartCoroutine(startBehaviorHit(collision));
        }
        if (collision.CompareTag("GrShuriken") && collision.GetComponent<shurikenBullet>().isGoback)
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
            StartCoroutine(startBehaviorHit(collision));
        }
    }
    private void DropExp()
    {
        if (prefExp != null)
        {
            Instantiate(prefExp, transform.position, Quaternion.identity);
        }
    }
    private void Die()
    {
        Debug.Log("Monster is dead!");
        Destroy(gameObject, knockBackDuration);
    }

    public IEnumerator startBehaviorHit(Collider2D collision)
    {
        knockBackState(collision);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitLagDur);
        Time.timeScale = 1;

        yield return new WaitForSeconds(knockBackDuration);
        alertState();

        yield return new WaitForSeconds(hitLagWait);
        endKnockBackState();
    }

    void knockBackState(Collider2D collision)
    {

        var obj = Instantiate(hiteffect, transform.position, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 180)));
        var dur = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(obj, dur);

        anim.enabled = false;
        rb.velocity = Vector2.zero;
        gotHit = true;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.z = 0;
        rb.AddForce(-direction * knockBackForce);
        spriteRenderer.color = new Color(1, 0.47f, 0.47f, 1);
    }
    private void endKnockBackState()
    {
        GetComponent<Animator>().enabled = true;
        gotHit = false;
    }

    private void alertState()
    {
        rb.velocity = Vector2.zero;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
