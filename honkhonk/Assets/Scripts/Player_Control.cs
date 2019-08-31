using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float momentum;
    public float horizontalMove = 0f;
    private float jumpForce = 200f;

    [SerializeField] private Transform groundCheck;

    const float groundedRadius = 0.2f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private bool facingRight = true;
    private bool grounded = true;
    private Vector3 playerVelocity = Vector3.zero;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }


    public void Move(float move, bool jump)
    {
        //find target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, playerRigidbody.velocity.y);
        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref playerVelocity, movementSmoothing);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (jump && grounded)
        {
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
        }


    }

    public void Flip()
    {
        // Change player orientation
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
