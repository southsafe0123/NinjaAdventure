using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRandomMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float changeInterval = 2.0f;

    private Vector2 randomDirection;
    private float timer = 0;

    private void Start()
    {
        // Khởi tạo hướng di chuyển ngẫu nhiên ban đầu
        GetRandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển enemy theo hướng hiện tại
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Tính toán thời gian và thay đổi hướng sau một khoảng thời gian
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GetRandomDirection();
            timer = 0;
        }
    }

    private void GetRandomDirection()
    {
        // Tạo một hướng ngẫu nhiên bằng cách tạo một vector có các thành phần ngẫu nhiên trong khoảng [-1, 1]
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
