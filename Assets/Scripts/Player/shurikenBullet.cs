using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isHitSth = false;
    private Animator anim;
    public GameObject arrow;
    public static float s_shurikenDamage = 1;
    public GameObject hiteffect;
    public GameObject audioSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHitSth)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("wall"))
        {
            StartCoroutine(changeBehavior());
            if (collision.CompareTag("enemy"))
            {
                MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_ENEMY_HIT_SOUND);
            }

            if (collision.CompareTag("wall"))
            {
                MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND);
            }
        }

    }

    IEnumerator changeBehavior()
    {
        isHitSth = true;
        anim.enabled = false;

        yield return null;
        gameObject.tag = "GrShuriken";
        arrow.SetActive(true);
    }
}
