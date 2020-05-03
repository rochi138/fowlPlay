using UnityEngine;
using System.Collections;
using ServiceLocator;
using System;

public class Goose : MonoBehaviour
{
    public Player_Control controller;
    public Animator animator;

    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool headbutt = false;
    public float upForce;                   //Upward force of the "flap".
    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity

    void Start() {
        // PlayerEventsService playerEventsService = Locator.Get<IPlayerEventsService>("PlayerEventsService");
        // if ( playerEventsService != null )
            Locator.Get<IPlayerEventsService>("PlayerEventsService").SpaceDown += (object sender, EventArgs e) => { jump = true; };
        // Locator.PlayerEvents.OnXDown += delegate { headbutt = true; };
        // Locator.GetAudioBase( "AudioService" ).playSound(0);
    }

    void OnDestroy() {
        Locator.Get<IPlayerEventsService>("PlayerEventsService").SpaceDown -= (object sender, EventArgs e) => { jump = true; };
        // Locator.PlayerEvents.OnXDown -= delegate { headbutt = true; };
    }
    
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("hozSpeed", Mathf.Abs(horizontalMove));

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