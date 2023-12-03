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
    public float delayShotBtw;
    public float bulletSpeed;
    private Vector2 targetPosition; // Vị trí mới của kẻ địch
    public float moveSpeed; // Tốc độ di chuyển của kẻ địch
    public float hitLagDur;
    public float knockBackDuration;
    public float hitLagWait;
    private bool gotHit;
    public Animator anim;
    public SpriteRenderer sprite;
    public float knockBackForce;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit) return;

        if (range.isPlayerInZone && !hasShot)
        {
            bullet();
            MoveToRandomPosition();
            RotationToPlayer();
        }

        // Di chuyển kẻ địch đến vị trí mới
        if (hasShot)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Debug.Log(targetPosition);
        }

    }

    void bullet()
    {
        //Vector3 direction = (range.player.position - transform.po sition).normalized;
        //GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        var obj = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
        obj.GetComponent<fireBulletScript>().speedBullet = bulletSpeed;

        hasShot = true; // Đánh dấu đã bắn đạn
        StartCoroutine(DelayShot());
    }

    IEnumerator DelayShot()
    {

        yield return new WaitForSeconds(delayShotBtw);
        hasShot = false;
        
        StopCoroutine(DelayShot());
    }

    void MoveToRandomPosition()
    {
        float randomX = Random.Range(transform.position.x-3, transform.position.x+3); // Chỉnh giới hạn di chuyển theo trục X
        float randomY = Random.Range(transform.position.y-3, transform.position.y+3); // Chỉnh giới hạn di chuyển theo trục Y

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

    private IEnumerator startBehaviorHit(Collider2D collision)
    {


        knockBackState(collision);

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitLagDur);
        Time.timeScale = 1;

        yield return new WaitForSeconds(knockBackDuration);
        alertState();

        yield return new WaitForSeconds(hitLagWait);
        endKnockBackState();
    }

    private void endKnockBackState()
    {
        anim.enabled = true;
        gotHit = false;
    }

    private void alertState()
    {
        rb.velocity = Vector2.zero;
        sprite.color = new Color(1, 1, 1, 1);
        range.gameObject.GetComponent<CircleCollider2D>().radius = 20;
    }

    void knockBackState(Collider2D collision)
    {
        anim.enabled = false;
        rb.velocity = Vector2.zero;
        gotHit = true;
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.z = 0;
        rb.AddForce(-direction * knockBackForce);
        sprite.color = new Color(1, 0.47f, 0.47f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            //hit by shuriken
            StartCoroutine(startBehaviorHit(collision));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall")|| collision.collider.CompareTag("enemy"))
        {
            targetPosition = transform.position;
        }
    }
}
