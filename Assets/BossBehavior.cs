using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public MonsterTriggerRange trigger;
    private Animator anim;
    public LineRenderer dangerLine;
    public float moveSpeed;
    public bool isHitWallDashState;
    public float timeFollow;
    public float timeChargeDash;
    public float timeCooldown;
    // Start is called before the first frame update
    void Start()
    {
        dangerLine.enabled = false;
        isHitWallDashState = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.isPlayerInZone)
        {
            anim.SetTrigger("idle-follow");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            isHitWallDashState = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            isHitWallDashState = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            isHitWallDashState = false;
        }
    }
}
