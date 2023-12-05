using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    public float speedSlowDown;
    public float dashCooldown;
    public bool isDashing;
    public bool canDash = true;
    public float timer;
    public Vector3 dashTarget;
    public TrailRenderer tr;
    public Animator anim;
    Vector2 move;
    public static Camera mainCamera;
    public float hitStopDur;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        if (!canDash) StartCoroutine(CooldownDash());

        if (isDashing || PlayerHealth.playerGotHit || Time.timeScale == 0||mainCamera == null) return;


        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");



        if (Input.GetMouseButtonDown(1) && canDash && !isDashing)
        {
            StartCoroutine(playerDashing());
        }

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        if (isDashing || PlayerHealth.playerGotHit || Time.timeScale == 0|| mainCamera == null)
        {
            return;
        }

        playerMove(move.x, move.y);
    }
    void playerMove(float moveX, float moveY)
    {
        if (moveX != 0 && moveY != 0)
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
        dashTarget = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = dashTarget - transform.position;

        canDash = false;
        isDashing = true;
        tr.emitting = true;

        rb.AddForce((dashDirection).normalized * dashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        tr.emitting = false;
    }
    IEnumerator CooldownDash()
    {

        timer += Time.deltaTime;
        if (timer > dashCooldown)
        {
            timer = 0;
            canDash = true;
        }

        yield return null;
    }

    public void resetCooldownDash()
    {
        StopCoroutine(CooldownDash());
        StartCoroutine(HitStop());
        timer = 0;
        canDash = true;
    }


    //stop moment when player get shuriken
    IEnumerator HitStop()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(hitStopDur);
        Time.timeScale = 1;
    }

}
