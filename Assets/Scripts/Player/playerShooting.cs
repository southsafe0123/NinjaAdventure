using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shurikenBullet;
    [SerializeField] private Transform firingPoint;
    public PlayerMovement player;
    bool isShooting;
    public Vector3 shootingPos;
    public float shurikenSpeed;
    public float shurikenPLayerHave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shurikenPLayerHave == 0)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(shoot());
        }
    } 

    IEnumerator shoot() 
    {
        yield return null;

        shurikenPLayerHave--;

        shootingPos = Input.mousePosition;
        shootingPos.z = 0;

        shootingPos = PlayerMovement.mainCamera.ScreenToWorldPoint(shootingPos);

        shootingPos = shootingPos - transform.position;

        var obj = Instantiate(shurikenBullet, firingPoint.position, firingPoint.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(shootingPos.x,shootingPos.y).normalized * shurikenSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GrShuriken"))
        {
            
            player.resetCooldownDash();
            isShooting = false;
            shurikenPLayerHave++;
            Destroy(collision.gameObject,0.03f);
        }
    }
}
