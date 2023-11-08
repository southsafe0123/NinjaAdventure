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
    private Camera mainCamera;
    public float shurikenSpeed;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(shoot());
        }
    } 

    IEnumerator shoot() 
    {
        yield return null;

        shootingPos = Input.mousePosition;
        shootingPos.z = 0;

        shootingPos = mainCamera.ScreenToWorldPoint(shootingPos);

        shootingPos = shootingPos - transform.position;

        var obj = Instantiate(shurikenBullet, firingPoint.position, firingPoint.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingPos.x,shootingPos.y).normalized * shurikenSpeed;
        
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
