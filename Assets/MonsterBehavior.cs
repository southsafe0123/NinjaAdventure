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

    private void Start()
    {
        gotHit = false;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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

    private void MoveToPlayer()
    {
        Vector3 directionToPlayer = (range.player.position - transform.position).normalized;
        directionToPlayer.z = 0;

        rb.velocity = new Vector3(directionToPlayer.x * monsSpeed,directionToPlayer.y * monsSpeed, directionToPlayer.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            //hit by shuriken
            Debug.Log("gothit");
            StartCoroutine(startBehaviorHit(collision));
        }
    }

    private IEnumerator startBehaviorHit(Collider2D collision)
    {
        rb.velocity = Vector2.zero;
        gotHit = true;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.z = 0;
        rb.AddForce(-direction * knockBackForce);
        sprite.color = new Color(1, 0.47f, 0.47f, 1);
        yield return new WaitForSeconds(knockBackDuration);
        rb.velocity = Vector2.zero;
        sprite.color = new Color(1, 1, 1, 1);
        range.gameObject.GetComponent<CircleCollider2D>().radius = 20;
        yield return new WaitForSeconds(hitLagWait);
        gotHit = false;
    }

}
