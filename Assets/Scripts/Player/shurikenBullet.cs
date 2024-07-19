using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI coolDownText;
    public int goBackTime;
    public float timer;
    public bool isGoback;
    public float goBackSpeed;
    private Vector2 lastedPlayerPos;
    private Coroutine coroutine;
    private Tweener tweener;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            coolDownText.text = Mathf.Ceil(timer).ToString(); 
        }

        if((Vector2)transform.position == lastedPlayerPos && isGoback)
        {
            isGoback = false;
            if(coroutine == null) coroutine = StartCoroutine(changeBehavior());
            
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isHitSth && !isGoback)
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("wall"))
        {
            if(coroutine== null) coroutine = StartCoroutine(changeBehavior());

            if (gameObject.tag == "GrShuriken")
            {
                if (collision.CompareTag("enemy") && isGoback)
                {
                    MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_ENEMY_HIT_SOUND).Play();
                }
                return;
            }
            if (collision.CompareTag("enemy"))
            {
                MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_ENEMY_HIT_SOUND).Play();
            }

            if (collision.CompareTag("wall"))
            {
                MusicManager.Instance.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).Play();
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
        timer = goBackTime;
        yield return new WaitForSeconds(goBackTime);

        isGoback = true;
        lastedPlayerPos = PlayerSave.instance.gameObject.transform.position;
        tweener = transform.DOMove(lastedPlayerPos, 0.5f).SetEase(Ease.InBack);
        anim.enabled = true;
        arrow.SetActive(false);
        MusicManager.Instance.GetAudioSource(MusicManagerAudioName.ALERT_SHURIKEN_GO_BACK_SOUND).Play();

        coroutine = null;
    }
    private void OnDestroy()
    {
        tweener.Kill();
        tweener = null;
    }
}

