using UnityEngine;

public class KillZone2D : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player2D player = col.GetComponent<Player2D>();

            // วาปกลับ Checkpoint
            col.transform.position = player.respawnPoint;

            // รีเซ็ตแรง (สำคัญมาก ไม่งั้นเด้ง/ตกซ้ำ)
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}