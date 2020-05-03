using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour
{
    protected Rigidbody2D rb;

    // Input Keys - should be the same across characters
    protected Command buttonLeft, buttonRight;

    // Bind keys here
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Handle input here
    protected abstract void Update();

    // Check for input and execute commands here
    protected abstract void HandleInput();
}
