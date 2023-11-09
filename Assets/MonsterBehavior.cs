using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public MonsterTriggerRange range;
    public float monsSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool gotHit;
    public float knockBackForce;
    public float knockBackDuration;
    public float hitLagWait;
    private Animator anim;
    public float hitLagDur;

    private void Start()
    {
        gotHit = false;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(gotHit) return ;

        if (range.isPlayerInZone)
        {
            RotationToPlayer();
            MoveToPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            //hit by shuriken
            StartCoroutine(startBehaviorHit(collision));
        }
    }

    private IEnumerator startBehaviorHit(Collider2D collision)
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

    private void RotationToPlayer()
    {

        if (transform.position.x > range.player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
    private void endKnockBackState()
    {
        anim.enabled = true;
        gotHit = false;
    }

    private void alertState()
    {
        rb.velocity = Vector2.zero;
        sprite.color = new Color(1, 1, 1, 1);
        range.gameObject.GetComponent<CircleCollider2D>().radius = 20;
    }

    void knockBackState(Collider2D collision)
    {
        anim.enabled = false;
        rb.velocity = Vector2.zero;
        gotHit = true;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.z = 0;
        rb.AddForce(-direction * knockBackForce);
        sprite.color = new Color(1, 0.47f, 0.47f, 1);
    }

    private void MoveToPlayer()
    {
        Vector3 directionToPlayer = (range.player.position - transform.position).normalized;
        directionToPlayer.z = 0;
        anim.SetBool("Move", true);
        rb.velocity = new Vector3(directionToPlayer.x * monsSpeed, directionToPlayer.y * monsSpeed, directionToPlayer.z);
    }

}
