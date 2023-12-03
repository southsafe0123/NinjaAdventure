using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rd;
    public float speedBullet = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction); // Xoay viên đạn về phía người chơi
        rd.velocity = new Vector2(direction.x, direction.y).normalized * speedBullet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")|| collision.collider.CompareTag("wall"))
        {
            Destroy(gameObject);
        } 
    }

     void OnTriggerEnter2D(Collider2D collision)
    { 
     if(collision.CompareTag("shuriken"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
