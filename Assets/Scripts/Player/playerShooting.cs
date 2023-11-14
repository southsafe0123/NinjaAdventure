using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject shurikenBullet;
    [SerializeField] private Transform firingPoint;
    public PlayerMovement player;
    bool isShooting;
    public Vector3 shootingPos;
    public float shurikenSpeed;
    public static float ShurikenPLayerHave;
    public float shurikenPlayerHave;

    // Start is called before the first frame update
    void Start()
    {
        ShurikenPLayerHave = shurikenPlayerHave;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShurikenPLayerHave == 0)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (Input.GetMouseButtonDown(0) && !isShooting && Time.timeScale == 1)
        {
            StartCoroutine(shoot());
        }
    } 

    IEnumerator shoot() 
    {
        yield return null;

        ShurikenPLayerHave--;

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
            if (player.timer != 0)
            {
                player.resetCooldownDash();
            }
            isShooting = false;
            ShurikenPLayerHave++;
            Destroy(collision.gameObject,0.03f);
        }
    }
}
