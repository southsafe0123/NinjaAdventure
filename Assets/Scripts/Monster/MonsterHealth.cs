using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public MonsterBehavior monster;
    public GameObject prefExp;
    private bool lockDead;

    private void Start()
    {
        monster = GetComponent<MonsterBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            GetDamage(shurikenBullet.s_shurikenDamage);
        }
    }
    private void Update()
    {
        if (health <= 0 && !lockDead)
        {
            lockDead = true;
            DropExp();
            Die();
        }
    }

    void GetDamage(float damage)
    {

        health -= (int)damage;
    }

    private void Die()
    {
        Debug.Log("Monster is dead!");

        // Tiếp tục xử lý khi slime chết
        Destroy(gameObject, monster.knockBackDuration);
    }

    private void DropExp()
    {
        if (prefExp != null)
        {
            Instantiate(prefExp, transform.position, Quaternion.identity);
        }
    }
}
