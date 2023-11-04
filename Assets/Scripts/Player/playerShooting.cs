using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shurikenBullet;
    [SerializeField] private Transform firingPoint;
    bool isShooting;
    public Vector3 shootingPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootingDirection = shootingPos - transform.position;        

        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            shoot(shootingDirection);
            isShooting = true;
        }
    }

    private void shoot(Vector3 shootingDirection)
    {
        var obj = Instantiate(shurikenBullet, firingPoint.position, firingPoint.rotation);
        obj.GetComponent<shurikenBullet>().shootingDirection = shootingDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GrShuriken"))
        {
            Destroy(collision.gameObject);
            isShooting = false;
        }
    }
}
