using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GooseCommands {

    /// <summary>
    /// Moves Goose left and right
    /// </summary>
    public class MoveHorizontal : Command
    {
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

            float runSpeed = 30f;
            float horizontalMove = 0f;

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
    /// <summary>
    /// Goose performs dash.
    /// Can be used when in the air.
    /// Can trigger events upon impact with key objects.
    /// </summary>
    public class Headbutt : Command
    {
        [Range(0, .3f)] [SerializeField] private readonly float movementSmoothing = .05f;
        public override void Execute(Rigidbody2D rigidbody, Command command)
        {
            //public void Headbutt()
            //{
            //    if (!headbuttTired)
            //    {
            //        headbutt = true;
            //        Vector3 targetVelocity;
            //        targetVelocity = new Vector2(facingRight ? 80f : -80f, playerRigidbody.velocity.y);
            //        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref playerAcceleration, movementSmoothing);
            //        headbuttTired = true;
            //    }
            //}

            Move(rigidbody);
        }

        public override void Move(Rigidbody2D rigidbody)
        {

        }
    }
    /// <summary>
    /// Goose moves vertically.
    /// Can only be used when grounded.
    /// </summary>
    public class Jump : Command
    {
        public override void Execute(Rigidbody2D rigidbody, Command command)
        {
            Move(rigidbody);
        }

        public override void Move(Rigidbody2D rigidbody)
        {
            //    if (jump && grounded) {
            //        playerRigidbody.AddForce(new Vector2(0f, jumpForce));
            //    }
            //}
        }
    }
}