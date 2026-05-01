using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool activated = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!activated && col.CompareTag("Player"))
        {
            Player2D player = col.GetComponent<Player2D>();
            player.respawnPoint = transform.position;

            activated = true;

            Debug.Log("Checkpoint Saved!");

            // เปลี่ยนสีให้รู้ว่าโดนแล้ว (ถ้ามี Sprite)
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = Color.green;
            }
        }
    }
}