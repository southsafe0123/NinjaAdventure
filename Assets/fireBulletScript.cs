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

    // Update is called once per frame
    void Update()
    {
        
    }
}
