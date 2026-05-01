using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    static Checkpoint currentCheckpoint; // 👈 ตัวล่าสุด

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;

        Player2D player = col.GetComponent<Player2D>();
        player.respawnPoint = transform.position;

        Debug.Log("Checkpoint Saved!");

        // 👉 ปิดอันเก่า
        if (currentCheckpoint != null && currentCheckpoint != this)
        {
            currentCheckpoint.Deactivate();
        }

        // 👉 เปิดอันนี้
        Activate();
        currentCheckpoint = this;
    }

    void Activate()
    {
        if (sr != null)
            sr.color = Color.green;
    }

    void Deactivate()
    {
        if (sr != null)
            sr.color = Color.white;
    }
}