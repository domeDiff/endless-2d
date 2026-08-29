using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;

    [SerializeField] private LayerMask groundLayer;

    private float fixedX;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedX = transform.position.x;
    }
    private void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        CheckGround();

        if(Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }

        transform.position = new Vector3(fixedX, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        rb.position = new Vector2(fixedX, rb.position.y);
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("PLAYER HIT AN OBSTACLE!");
        }
    }
}
