using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float standTime = 1.5f;
    public float respawnDelay = 2f; // เวลาก่อนเกิดใหม่

    float timer = 0f;
    bool playerOn = false;
    bool isTriggered = false;

    Vector3 startPos;
    Rigidbody2D rb;
    Collider2D col;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        startPos = transform.position;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (playerOn && !isTriggered)
        {
            timer += Time.deltaTime;

            if (timer >= standTime)
            {
                StartCoroutine(DropAndRespawn());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = false;
            timer = 0f;
        }
    }

    IEnumerator DropAndRespawn()
    {
        isTriggered = true;

        // 👉 เริ่มตก
        rb.bodyType = RigidbodyType2D.Dynamic;

        // 👉 รอให้ตกก่อน
        yield return new WaitForSeconds(1f);

        // 👉 ซ่อน (ไม่ใช้ Destroy แล้ว)
        sr.enabled = false;
        col.enabled = false;

        // 👉 รอเกิดใหม่
        yield return new WaitForSeconds(respawnDelay);

        // 👉 รีเซ็ตทุกอย่าง
        transform.position = startPos;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        sr.enabled = true;
        col.enabled = true;

        timer = 0f;
        playerOn = false;
        isTriggered = false;
    }
}