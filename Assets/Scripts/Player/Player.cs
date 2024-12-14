using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed in the Inspector
    public float jumpForce = 5f; // Force applied to the jump
    public Animator animator;
    private bool isGrounded; // To track if the player is on the ground
    private Rigidbody2D rb; // Rigidbody2D component
    private bool isFacingRight = true; // To track which direction the player is facing

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from the horizontal axis (A/D keys or Left/Right arrows)
        float move = Input.GetAxis("Horizontal");

        // Update animator with speed
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Move the player left or right
        transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);

        // Flip the player when changing direction
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Player is no longer on the ground
            animator.SetBool("IsJumping", true); // Trigger jumping animation
        }
    }

    // Check for collisions with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false); // Stop jumping animation
        }
    }

    // Flip the player's direction
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the x-axis
        transform.localScale = scale;
    }
}
