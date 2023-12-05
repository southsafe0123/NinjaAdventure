using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float PlayerCurrentHealth;
    public static float PlayerMaxHeath;
    public float playerCurrentHealth;
    public float playerMaxHeath;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public static bool playerGotHit;
    public float knockBackForce;
    public float knockBackDuration;
    public float invisDuration;
    public static bool playerInvis;
    public float freezeTimeDur;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy") && !playerInvis)
        {
            PlayerCurrentHealth--;
            if(PlayerCurrentHealth <= 0)
            {
                Time.timeScale = 0f;
                gameObject.SetActive(true);
                
            }
            StartCoroutine(gotHitState(collision));
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        PlayerCurrentHealth = playerCurrentHealth;
        Debug.Log("starting");
        PlayerMaxHeath = playerMaxHeath;

    }
    IEnumerator gotHitState(Collision2D collision)
    {

        knockBackState(collision);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(freezeTimeDur);
        Time.timeScale = 1;
            
        yield return new WaitForSeconds(knockBackDuration);
        
        invisState();
        yield return new WaitForSeconds(invisDuration);
        normalState();
    }

    private void normalState()
    {
        playerInvis = false;
        sprite.color = new Color(1, 1, 1, 1);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private void invisState()
    {
        playerGotHit = false;
        sprite.color = new Color(1, 1, 1, 0.5f);
    }

    private void knockBackState(Collision2D collision)
    {
        playerInvis = true;
        playerGotHit = true;
        sprite.color = new Color(1, 0.47f, 0.47f, 1);


        Physics2D.IgnoreLayerCollision(8, 9, true);


        rb.velocity = Vector2.zero;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.z = 0;
        rb.AddForce(-direction * knockBackForce);
        sprite.color = new Color(1, 0.47f, 0.47f, 1);
    }
}
