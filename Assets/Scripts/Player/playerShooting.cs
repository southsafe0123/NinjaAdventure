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
    public static float ShurikenPLayerHave;
    public float shurikenPlayerHave;
    public float hitStopDur;

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

        if (Input.GetMouseButtonDown(0) && !isShooting)
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
                StartCoroutine(HitStop());
            player.resetCooldownDash();
            isShooting = false;
            ShurikenPLayerHave++;
            Destroy(collision.gameObject,0.03f);
        }
    }

    IEnumerator HitStop()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitStopDur);
        Time.timeScale = 1;
    }
}
