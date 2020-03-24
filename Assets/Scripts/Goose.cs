using UnityEngine;
using System.Collections;

public class Goose : MonoBehaviour
{
    public Player_Control controller;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool headbutt = false;
    public float upForce;                   //Upward force of the "flap".
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity

    void Awake() {
        PlayerEvents.OnJumpDown += delegate { jump = true; };
        PlayerEvents.OnXDown += delegate { headbutt = true; };
    }

    void OnDestroy() {
        PlayerEvents.OnJumpDown -= delegate { jump = true; };
        PlayerEvents.OnXDown -= delegate { headbutt = true; };
    }
    
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Moves character
        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;

        //goose headbutts
        if (headbutt == true) {
            controller.Headbutt();
            headbutt = false;
        }
    }
}