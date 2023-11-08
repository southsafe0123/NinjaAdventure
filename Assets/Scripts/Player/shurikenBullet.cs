using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isHitSth = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHitSth)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") || collision.CompareTag("enemy")) {
            StartCoroutine(changeBehavior());
            
        }
    }
    
    IEnumerator changeBehavior()
    {
        isHitSth = true;
        anim.enabled = false;
        yield return new WaitForSeconds(0.05f);
        gameObject.tag = "GrShuriken";
        yield return null;
        StopCoroutine(changeBehavior());
    }
}
