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
    bool isDashing;
    bool canDash = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        playerMove(moveX, moveY);

        if (Input.GetKey(KeyCode.Space) && canDash)
        {
            StartCoroutine(playerDashing(moveX, moveY));
        }
    }

    void playerMove(float moveX, float moveY)
    {
        
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    IEnumerator playerDashing(float moveX, float moveY)
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveX * dashSpeed, moveY * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
