using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    private float moveX;
    private float moveY;
    bool isDashing;
    bool canDash = true;
    public Vector3 dashTarget;
    public TrailRenderer tr;
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

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        playerMove(moveX, moveY);

        if (Input.GetMouseButton(1) && canDash)
        {
            StartCoroutine(playerDashing());
        }
    }

    void playerMove(float moveX, float moveY)
    {
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    IEnumerator playerDashing()
    {
        dashTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dashTarget.z = transform.position.z;
        Vector3 dashDirection = dashTarget - transform.position;
        dashDirection.Normalize();
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        rb.velocity = Vector3.Slerp(transform.position ,dashDirection , 1) * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
