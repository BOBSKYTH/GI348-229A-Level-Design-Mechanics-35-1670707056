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

    void FixedUpdate() // 👈 ใช้กับ Physics
    {
        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // 👉 กลับตัวเฉพาะตอนชน "Ground"
        if (col.gameObject.CompareTag("Ground"))
        {
            direction *= -1;

            // พลิกตัว
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        Player2D player = col.GetComponent<Player2D>();
        Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

        // รีเซ็ตแรงก่อน
        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        // วาปกลับ Checkpoint
        col.transform.position = player.respawnPoint;
    }
}