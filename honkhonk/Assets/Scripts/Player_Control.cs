using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float momentum;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        animator.SetBool("Walk", false);
        Vector2 move = Vector2.zero;
        momentum = velocity.x;
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpTakeOffSpeed;
        }
        move.x = Input.GetAxis("Horizontal");

        if (move.x != 0)
            {
            animator.SetBool("Walk", true);
        }


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        

        targetVelocity = move * maxSpeed;
        if (grounded == false)
        {
            targetVelocity.x = momentum;
        }
        else
        {
            momentum = 0;
        }
    }
}
