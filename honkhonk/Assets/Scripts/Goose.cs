using UnityEngine;
using System.Collections;

public class Goose : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement

    public Player_Control controller;

    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool headbutt = false;

    public bool isEnabled;
    public float upForce;                   //Upward force of the "flap".
    public bool isGrounded;
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity

    private void FixedUpdate()
    {
        //Moves character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

        //goose headbutts
        if (headbutt == true)
        {
            controller.Headbutt();
            headbutt = false;
        }
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            headbutt = true;
        }
    }
}