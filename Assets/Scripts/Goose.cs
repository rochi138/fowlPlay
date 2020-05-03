using UnityEngine;
using System.Collections;

public class Goose : Player_Control
{

    //public static Player_Control controller;
    public InputHandler inputHandler;

    public float runSpeed = 40f;
    //private float horizontalMove = 0f;
    private bool jump = false;
    private bool headbutt = false;
    public float upForce;                   //Upward force of the "flap".
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity

    void Awake() {
        GM.PlayerEvents.OnJumpDown += delegate { jump = true; };
        GM.PlayerEvents.OnXDown += delegate { headbutt = true; };
    }

    void OnDestroy() {
        GM.PlayerEvents.OnJumpDown -= delegate { jump = true; };
        GM.PlayerEvents.OnXDown -= delegate { headbutt = true; };
    }
    
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("hozSpeed", Mathf.Abs(horizontalMove));
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        inputHandler = new InputHandlerGoose(playerRigidbody);
    }
}
