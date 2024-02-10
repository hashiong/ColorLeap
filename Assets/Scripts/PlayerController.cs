using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    public float speed = 5;
    public float jumpAmount = 8;
    float groundCheckRadius; // Radius of the ground check circle

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Active Platform");

        // Calculate the ground check radius using the circle collider attached to the GameObject
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            groundCheckRadius = circleCollider.radius;
        }

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        // Disable colliders of all platforms

        int inactiveLayer = LayerMask.NameToLayer("Inactive Platform");
        foreach (GameObject platform in platforms)
        {
            Collider2D collider = platform.GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
                collider.gameObject.layer = inactiveLayer;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Perform ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        bool player_jump = Input.GetKeyDown(KeyCode.Space);

        if (player_jump && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }

  
}
