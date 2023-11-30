using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MatroiMovement : MonoBehaviour
{
    public MonsterTriggerRange range;
    public float monsSpeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab; // Prefab của đạn
    public Transform bulletPos; //
    //public float bulletSpeed; // Tốc độ của đạn
    private bool hasShot = false;

    private Vector2 targetPosition; // Vị trí mới của kẻ địch
    public float moveSpeed; // Tốc độ di chuyển của kẻ địch


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationToPlayer();
        if (range.isPlayerInZone && !hasShot)
        {
            bullet();
            MoveToRandomPosition();
        }

        // Di chuyển kẻ địch đến vị trí mới
        if(hasShot)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
       
    }

    void bullet()
    {
        //Vector3 direction = (range.player.position - transform.position).normalized;
        //GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);

        hasShot = true; // Đánh dấu đã bắn đạn
        StartCoroutine(DelayShot());
    }

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(7);
        hasShot = false;
        StopCoroutine(DelayShot());
    }

    void MoveToRandomPosition()
    {
        float randomX = Random.Range(-8f, 8f); // Chỉnh giới hạn di chuyển theo trục X
        float randomY = Random.Range(-4f, 4f); // Chỉnh giới hạn di chuyển theo trục Y

        targetPosition = new Vector2(randomX, randomY); // Tạo tọa độ mới
        
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
