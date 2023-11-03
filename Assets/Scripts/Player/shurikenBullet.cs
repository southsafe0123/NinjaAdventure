using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shootingSpeed;
    bool isHitSth = false;
    public Vector3 shootingDirection;
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
        if (!isHitSth)
        {
            rb.velocity = Vector3.Slerp(transform.position, shootingDirection.normalized, 1) * shootingSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall") || collision.CompareTag("enemy")) {
            isHitSth = true;
            gameObject.tag = "GrShuriken";
            anim.enabled = false;
        }
    }
}
