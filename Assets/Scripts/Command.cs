using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command : MonoBehaviour
{
    protected float horizontalMove = 0f;
    protected float jumpForce = 410f;
    protected float maxSpeed = 7;
    protected float jumpTakeOffSpeed = 7;
    protected float momentum;
    public LayerMask groundLayers = 0;
    protected Vector3 playerAcceleration = Vector3.zero;
    protected float runSpeed = 30f;

    public abstract void Execute(Rigidbody2D rigidbody, Command command);

    public virtual void Move(Rigidbody2D rigidbody) { }

}

// -- Child classes -- //
    
public class GooseMoveHorizontal : Command
{
    [Range(0, .3f)] [SerializeField] private readonly float movementSmoothing = .05f;

    public override void Execute(Rigidbody2D rigidbody, Command command)
    {
        Move(rigidbody);
    }

    public override void Move(Rigidbody2D rigidbody)
    {
        void Flip()
        {
            Vector3 scale = rigidbody.transform.localScale;
            scale.x *= -1;
            rigidbody.transform.localScale = scale;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove > 0 && rigidbody.transform.localScale.x < 0)
        {
            Flip();
        }
        else if (horizontalMove < 0 && rigidbody.transform.localScale.x > 0)
        {
            Flip();
        }

        Vector3 targetVelocity = new Vector2(horizontalMove * Time.deltaTime * 10f, rigidbody.velocity.y);

        
        //rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref playerAcceleration, movementSmoothing);
        rigidbody.velocity = targetVelocity;


    }

}


