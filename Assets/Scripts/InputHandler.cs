using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour

{
    // Char we controlling with keys
    public new Rigidbody2D rb;

    // Input Keys
    protected Command buttonLeft, buttonRight;


    // Initiate class with character type
    public InputHandler(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    public abstract void HandleInput();
}
