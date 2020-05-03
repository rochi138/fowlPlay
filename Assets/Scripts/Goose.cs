using UnityEngine;
using System.Collections;

public class Goose : PlayerController
{
    public InputHandlerGoose inputHandler;

    public float runSpeed = 30f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool headbutt = false;

    public BoxCollider2D platformCollider;
    public Collider2D gooseCollider;
    private Vector3 playerVelocity = Vector3.zero;      //initial velocity

    protected override void Awake() {
        base.Awake();
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

    //destroys breakable objects
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    //make asynch later; else goose will still break things when falling thru air :))))
    //    if (headbutt == true && other.gameObject.tag == "Breakable")
    //    {
    //        Debug.Log("collision");
    //        Destroy(other.gameObject);
    //    }
    //    headbutt = false;
    //}
}
