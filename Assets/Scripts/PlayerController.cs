using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;

    public Animator animator;
    protected Rigidbody2D playerRigidbody;
    //public bool grounded{ 
    //    get { return Physics2D.OverlapCircle(groundCheck.position, GameConstants.groundedRadius, groundLayers); } 
    //}

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Initialize InputHandler here
    /// </summary>
}
