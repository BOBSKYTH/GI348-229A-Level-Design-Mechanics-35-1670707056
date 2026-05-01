using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{
    
    public float speed = 5f;
    public float jumpForce = 7f;
    public bool hasKey = false;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private float _moveInput;
    private bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 👉 รับค่า Input (A / D)
        if (Keyboard.current != null)
        {
            _moveInput = (Keyboard.current.dKey.isPressed ? 1 : 0) 
                        - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }

        // 👉 เดิน
        _rb.linearVelocity = new Vector2(_moveInput * speed, _rb.linearVelocity.y);

        // 👉 พลิกตัวละคร
        if (_moveInput < 0) _spriteRenderer.flipX = true;
        else if (_moveInput > 0) _spriteRenderer.flipX = false;

        // 👉 กระโดด
        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }
    }

    // 👉 เช็คพื้น
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}