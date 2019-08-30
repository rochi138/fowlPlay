using UnityEngine;
using System.Collections;

public class Goose : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement

    public Player_Control controller;

    public float runSpeed = 40f;
    private float horizontalMove = 0f;

    public bool isEnabled;
    public float upForce;                   //Upward force of the "flap".
    public bool isGrounded;
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private bool facingRight = true;        //Initial orientation of bird
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity


    //void Start()
    //{
    //    //Get reference to the Animator component attached to this GameObject.
    //    //anim = GetComponent<Animator>();
    //    //Get and store a reference to the Rigidbody2D attached to this GameObject.
    //    //rb2d = GetComponent<Rigidbody2D>();

    //    //gooseCollider = GameObject.FindGameObjectWithTag("goose").GetComponent<Collider2D>();

    //    isEnabled = true;
    //    isGrounded = true;
        
    //}

    private void FixedUpdate()
    {
        //Moves character
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }

    void Update()
    {
        //if (isEnabled)
        //{
        //    if (Input.GetKeyDown("space"))
        //    {
        //        rb2d.velocity = Vector2.zero;
        //        if (isGrounded)
        //        {
        //            rb2d.AddForce(new Vector2(0, upForce * 3));
        //        }
        //        else
        //        {
        //            rb2d.AddForce(new Vector2(0, upForce));
        //        }
        //        isGrounded = false;

        //    }
        //}
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

    }

    //void OnCollisionEnter2D(Collision2D theCollision)
    //{
    //    if (theCollision.gameObject.tag == "platform")
    //    {
    //        Debug.Log("crash");
    //        isGrounded = true;
    //    }
    //}

    //public void toggle ()
    //{
    //    Debug.Log("goose toggle");
    //    isEnabled = !isEnabled;
    //}

}