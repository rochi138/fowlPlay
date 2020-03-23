using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float momentum;
    public LayerMask groundLayers = 0;
    public float horizontalMove = 0f;
    private float jumpForce = 410f;

    [SerializeField] private Transform groundCheck;

    const float groundedRadius = 0.2f;
    private Rigidbody2D playerRigidbody;
    private bool facingRight = true;
    public bool grounded = false;
    private bool headbutt = false;
    private bool headbuttTired = false;      //checks if goose has headbutted
    private Vector3 playerAcceleration = Vector3.zero;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        //checks if player is on a platform
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, groundLayers);      //add layermask check
        headbuttTired = !grounded;
    }

    //destroys breakable objects
    public void Headbutt() {
        if (!headbuttTired)
        {
            headbutt = true;
            Vector3 targetVelocity;
            if (facingRight)
            {
                targetVelocity = new Vector2(80f, playerRigidbody.velocity.y);
            }
            else
            {
                targetVelocity = new Vector2(-80f, playerRigidbody.velocity.y);
            }
            playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref playerAcceleration, movementSmoothing);
            headbuttTired = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //make asynch later; else goose will still break things when falling thru air :))))
        if (headbutt == true && other.gameObject.tag == "Breakable") {
            Debug.Log("collision");
            Destroy(other.gameObject);
        }
        headbutt = false;
    }

    public void Move(float move, bool jump) {
        //find target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, playerRigidbody.velocity.y);

        //smooths transition from one velocity to next
        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref playerAcceleration, movementSmoothing);

        if (move > 0 && !facingRight) {
            Flip();
        } else if (move < 0 && facingRight) {
            Flip();
        }

        if (jump && grounded) {
            playerRigidbody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void Flip() {
        // Change player orientation
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public bool getHeadbutt() {
        return headbutt;
    }
}
