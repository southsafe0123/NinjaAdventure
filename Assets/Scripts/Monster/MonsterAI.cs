using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển của quái vật
    public float maxY = 5f; // Giới hạn di chuyển lên trên
    public float minY = -5f; // Giới hạn di chuyển xuống dưới

    private Rigidbody2D rb;
    private bool movingUp = true; // Biến kiểm tra quái vật đang di chuyển lên hay xuống

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveUpDown();
    }

    void MoveUpDown()
    {
        // Nếu quái vật đang di chuyển lên và vượt quá giới hạn lên trên, chuyển hướng xuống
        if (movingUp && transform.position.y >= maxY)
        {
            movingUp = false;
            // Đảo hình dạng khi đến giới hạn lên trên
            Flip();
        }
        // Nếu quái vật đang di chuyển xuống và vượt quá giới hạn xuống dưới, chuyển hướng lên
        else if (!movingUp && transform.position.y <= minY)
        {
            movingUp = true;
            // Đảo hình dạng khi đến giới hạn xuống dưới
            Flip();
        }

        // Di chuyển theo hướng đã xác định
        float direction = movingUp ? 1 : -1;
        rb.velocity = new Vector2(rb.velocity.x, direction * speed);
    }

    void Flip()
    {
        // Lật ngược hình dạng 180 độ quanh trục y
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}