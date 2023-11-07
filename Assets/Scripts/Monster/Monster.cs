using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * 1.5f, 0, 0);
        Vector2 scale = transform.localScale;
        scale.x *= scale.x > 0 ? -1 : 1;
        transform.localScale = scale;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            count++;
            if (count == 1) { 
            Destroy(collision.attachedRigidbody.gameObject);
        }
        }

    }
}
