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
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
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

        

        if (Input.GetMouseButton(1) && canDash)
        {
            StartCoroutine(playerDashing());
        }

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        playerMove(move.x, move.y);
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
        dashTarget =  mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = dashTarget - transform.position;

        canDash = false;
        isDashing = true;
        tr.emitting = true;

        rb.AddForce((dashDirection).normalized * dashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashDuration);
        
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        
        canDash = true;
    }
}
