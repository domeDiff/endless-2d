using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] Transform visual;
    [SerializeField] GameObject snowyVisual;
    [SerializeField] GameObject clemVisual;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;

    [SerializeField] private LayerMask groundLayer;

 private Animator animator;
    private float fixedX;
    private Rigidbody2D rb;

    private bool isDead;
    private bool isGrounded;
    private bool wasGrounded;
    private bool justLanded;
    private bool hasIniGrounded;
    public bool IsGrounded => isGrounded;
    public bool JustLanded => justLanded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedX = transform.position.x;
        
        LoadSelectedChar();

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
    }

    private void CheckGround()
    {
        wasGrounded = isGrounded;

        bool currentGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!hasIniGrounded)
        {
            isGrounded = currentGrounded;
            wasGrounded = currentGrounded;
            justLanded = false;
            hasIniGrounded = true;

            animator.SetBool("isJumping", !isGrounded);
            return;

        }
        else
        {
            wasGrounded = isGrounded;
            isGrounded = currentGrounded;

            justLanded = isGrounded && !wasGrounded;

            animator.SetBool("isJumping", !isGrounded);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            Debug.Log("PLAYER HIT AN OBSTACLE!");
        }

        animator.SetBool("isDead", isDead);
    }

    private void LoadSelectedChar()
    {
        string selectedChar = PlayerPrefs.GetString("SelectedChar", "snowy");

        snowyVisual.SetActive(selectedChar == "snowy");
        clemVisual.SetActive(selectedChar == "clem");

        animator = GetComponentInChildren<Animator>();
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (groundCheck == null)
    //        return;

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(
    //        groundCheck.position,
    //        groundCheckRadius
    //    );
    //}

}
