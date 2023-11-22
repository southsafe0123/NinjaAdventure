using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatroiMovement : MonoBehaviour
{
    public MonsterTriggerRange range;
    public float monsSpeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab; // Prefab của đạn
    public float bulletSpeed = 5f; // Tốc độ của đạn
    public float knockBackDuration;
    private bool hasShot = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (range.isPlayerInZone && !hasShot)
        {
            RotationToPlayer();
            bullet();
        }
    }

    private void bullet()
    {
        Vector2 direction = (range.player.position - transform.position).normalized;
        GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        hasShot = true; // Đánh dấu đã bắn đạn
        StartCoroutine(DelayShot());
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(2);
        hasShot = false;
        StopCoroutine(DelayShot());
    }

    private void RotationToPlayer()
    {

        if (transform.position.x > range.player.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    
}
