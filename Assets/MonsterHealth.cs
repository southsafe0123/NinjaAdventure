using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public MonsterBehavior monster;
    public GameObject prefExp;
    private bool lockDead;
    public float shurikenDamage;
    public static float s_shurikenDamage;
    public GameObject slimePrefab;

    private void Start()
    {
        s_shurikenDamage = shurikenDamage;
        monster = GetComponent<MonsterBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shuriken"))
        {
            GetDamage(s_shurikenDamage);
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

        // Sinh ra 2 bản sao giống y hệt
        SpawnClones();

        // Tiếp tục xử lý khi slime chết
        Destroy(gameObject, monster.knockBackDuration);
    }

    private void SpawnClones()
    {
        Debug.Log("Two clones are spawned!");

        // Tạo và in thông tin của hai bản sao mới
        GameObject clone1 = Instantiate(slimePrefab, transform.position, Quaternion.identity);
        GameObject clone2 = Instantiate(slimePrefab, transform.position, Quaternion.identity);

        // Thiết lập các thuộc tính của hai bản sao mới nếu cần
        Slime slime1 = clone1.GetComponent<Slime>();
        Slime slime2 = clone2.GetComponent<Slime>();

        slime1.Health = health;
        slime2.Health = health;
    }

    private void DropExp()
    {
        if (prefExp != null)
        {
            Instantiate(prefExp, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("prefExp is not assigned!");
        }
    }
}
