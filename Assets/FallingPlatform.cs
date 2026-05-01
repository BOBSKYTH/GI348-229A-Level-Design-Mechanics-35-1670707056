using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float standTime = 1.5f;   // ต้องยืนกี่วิถึงจะตก
    public float destroyTime = 2f;

    float timer = 0f;
    bool playerOn = false;
    bool isTriggered = false;
    

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (playerOn && !isTriggered)
        {
            timer += Time.deltaTime;

            if (timer >= standTime)
            {
                Drop();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag ("Player"))
        {
            playerOn = false;
            timer = 0f; // เดินออก = รีเซ็ตเวลา
        }
    }
    

    void Drop()
    {
        isTriggered = true;
        
        transform.position += (Vector3)Random.insideUnitCircle * 0.02f;

        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyTime);
    }
}