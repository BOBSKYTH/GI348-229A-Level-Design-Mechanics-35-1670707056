using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    int direction = 1;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // �����á��Ѻ���
        direction *= -1;

        // ��ԡ��� (optional)
        transform.localScale = new Vector3(direction, 1, 1);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.position = new Vector2(-18, 3);
        }
    }
}
