using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float speedSlowDown;
    public float dashCooldown;
    bool isDashing;
    bool canDash = true;
    public Vector3 dashTarget;
    public TrailRenderer tr;
    public Animator anim;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        dashTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        playerMove(move.x, move.y);

        if (Input.GetMouseButton(1) && canDash)
        {
            StartCoroutine(playerDashing());
        }

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.sqrMagnitude);

    }

    void playerMove(float moveX, float moveY)
    {
        if(moveX !=0  && moveY !=0)
        {
            rb.velocity = new Vector2(moveX * moveSpeed * speedSlowDown, moveY * moveSpeed * speedSlowDown);
        }
        else
        {
            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }
       
    }

    IEnumerator playerDashing()
    {
        rb.velocity = Vector2.zero;
        dashTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dashTarget.z = transform.position.z;
        Vector3 dashDirection = dashTarget - transform.position;
        dashDirection.Normalize();
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        rb.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
