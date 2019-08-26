using UnityEngine;
using System.Collections;

public class Goose : MonoBehaviour
{
    public bool isEnabled;
    public float upForce;                   //Upward force of the "flap".
    public bool isGrounded;
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;

    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

    void Start()
    {
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //gooseCollider = GameObject.FindGameObjectWithTag("goose").GetComponent<Collider2D>();

        isEnabled = true;
        isGrounded = true;
        
    }

    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetKeyDown("space"))
            {
                rb2d.velocity = Vector2.zero;
                if (isGrounded)
                {
                    rb2d.AddForce(new Vector2(0, upForce * 3));
                }
                else
                {
                    rb2d.AddForce(new Vector2(0, upForce));
                }
                isGrounded = false;

            }
        }

    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "platform")
        {
            Debug.Log("crash");
            isGrounded = true;
        }
    }

    public void toggle ()
    {
        Debug.Log("goose toggle");
        isEnabled = !isEnabled;
    }

}