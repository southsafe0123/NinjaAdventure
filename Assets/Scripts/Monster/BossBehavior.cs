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
    public bool inCDState;
    public float timeFollow;
    public float timeChargeDash;
    public float timeCooldown;
    public BossHealth bossHealth;
    private CamShake camShake;

    [Header("Camshake Stat in dashState")]
    public float magnitudeCamShake;
    public float timeCamShake;

    // Start is called before the first frame update
    void Start()
    {
        dangerLine.enabled = false;
        inCDState = false;
        anim = GetComponent<Animator>();
        bossHealth = GetComponent<BossHealth>();
        camShake = GameObject.Find("Main Camera").GetComponent<CamShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.isPlayerInZone)
        {
            if (trigger.player.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            anim.SetTrigger("idle-trigger");
        }

        if (bossHealth.health <= 0)
        {
            anim.Play("Boss_DieState");
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall") && inCDState)
        {
            MusicManager.Instance.GetAudioSource(MusicManagerAudioName.FROG_HIT_WALL_SOUND).Play();
            StartCoroutine(camShake.camShake(timeCamShake,magnitudeCamShake));
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
