using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public float coyoteTime = 0.15f;
    public float jumpBufferTime = 0.15f;

    float coyoteCounter;
    float jumpBufferCounter;
    public Vector2 respawnPoint;
    public bool hasKey = false;

    Rigidbody2D rb;
    float move;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // เดิน
        move = (Keyboard.current.dKey.isPressed ? 1 : 0)
               - (Keyboard.current.aKey.isPressed ? 1 : 0);

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // จับเวลาตอนอยู่พื้น
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        // กดกระโดดล่วงหน้า
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        // กระโดด
        if (jumpBufferCounter > 0 && coyoteCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}