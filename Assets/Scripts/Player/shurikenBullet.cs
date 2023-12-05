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
                var obj = Instantiate(hiteffect, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 180)));
                var dur = obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
                Destroy(obj, dur);
                foreach (Transform item in transform)
                {
                    if (item.name == "hitenemy")
                    {
                        Debug.Log(item.name);
                        item.GetComponent<AudioSource>().Play();
                    }
                }
            }

            if (collision.CompareTag("wall"))
            {
                foreach (Transform item in transform)
                {
                    if (item.name == "hitwall")
                    {
                        Debug.Log(item.name);
                        item.GetComponent<AudioSource>().Play();
                    }
                }
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
        StopCoroutine(changeBehavior());
    }
}
