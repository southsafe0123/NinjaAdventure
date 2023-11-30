using UnityEngine;

public class Slime : MonoBehaviour
{
    public int Health { get; set; }
    public GameObject prefab; // Prefab để sinh ra khi slime chết

    private void Start()
    {
        // Khởi tạo giá trị mặc định cho sức khỏe
        Health = 10;
    }

    // Phương thức này được gọi khi slime nhận sát thương
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    // Phương thức này được gọi khi slime chết
    private void Die()
    {
        Debug.Log("Slime is dead!");

        // Sinh ra 2 bản sao giống y hệt
        SpawnClones();

        // Xóa slime khi nó chết
        Destroy(gameObject);
    }

    // Phương thức để sinh ra 2 bản sao giống y hệt
    private void SpawnClones()
    {
        Debug.Log("Two clones are spawned!");

        // Tạo và in thông tin của hai bản sao mới
        GameObject clone1 = Instantiate(prefab, transform.position, Quaternion.identity);
        GameObject clone2 = Instantiate(prefab, transform.position, Quaternion.identity);

        // Thiết lập các thuộc tính của hai bản sao mới nếu cần
        Slime slime1 = clone1.GetComponent<Slime>();
        Slime slime2 = clone2.GetComponent<Slime>();

        slime1.Health = Health; // Giữ nguyên sức khỏe
        slime2.Health = Health; // Giữ nguyên sức khỏe
    }
}
