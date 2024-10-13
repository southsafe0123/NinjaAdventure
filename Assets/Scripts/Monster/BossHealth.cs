using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public AnimationCurve curveHealth;

    [Header("dont need to set health")]
    public float maxHealth;
    public float health;
    public GameObject prefExp;
    public bool isInCooldownState;
    public float numOfExp;
    public GameObject bossUI;
    public GameObject musicManager;
    

    private void Start()
    {
        //maxHealth = curveHealth.Evaluate(PlayerStatus.s_level);
        health = maxHealth;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            if (isInCooldownState)
            {
                GetDamage(shurikenBullet.s_shurikenDamage);
                GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_ENEMY_HIT_SOUND).Play();
                GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).Stop();
            }
            else
            {
                GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_ENEMY_HIT_SOUND).Stop();
                GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.SHURIKEN_WALL_HIT_SOUND).Play();
            }
        }
        if (collision.CompareTag("GrShuriken") && collision.GetComponent<shurikenBullet>().isGoback && isInCooldownState)
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
        }
    }
    private void Update()
    {
    }
    public void die()
    {
        GameSystem.MusicSystem.SetAudioClipForAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC, 5);
        GameSystem.MusicSystem.GetAudioSource(MusicManagerAudioName.BACKGROUND_MUSIC).Play();
        Destroy(gameObject);
    }
    public IEnumerator spawnEXP()
    {
        int i=0;
        while (i<numOfExp)
        {
            GameObject obj = Instantiate(prefExp,transform.position,Quaternion.identity) as GameObject;
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void GetDamage(float damage)
    {
        health -= damage;
    }
}
