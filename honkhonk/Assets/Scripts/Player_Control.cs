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

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private bool facingRight = true;
    private Vector3 playerVelocity = Vector3.zero;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    //protected override void ComputeVelocity()
    //{
    //    animator.SetBool("Walk", false);
    //    Vector2 move = Vector2.zero;
    //    momentum = velocity.x;
    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        velocity.y = jumpTakeOffSpeed;
    //    }
    //    move.x = Input.GetAxis("Horizontal");

    //    if (move.x != 0)
    //        {
    //        animator.SetBool("Walk", true);
    //    }


    //    bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
    //    if (flipSprite)
    //    {
    //        spriteRenderer.flipX = !spriteRenderer.flipX;
    //    }

    //    animator.SetBool("grounded", grounded);
        

    //    targetVelocity = move * maxSpeed;
    //    if (grounded == false)
    //    {
    //        targetVelocity.x = momentum;
    //    }
    //    else
    //    {
    //        momentum = 0;
    //    }
    //}

    public void Move(float move)
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
