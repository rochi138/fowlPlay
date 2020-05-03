using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerGoose : InputHandler
{
    public InputHandlerGoose(Rigidbody2D rb) : base(rb) { }

    // Start is called before the first frame update
    override protected void Start()
    {
        buttonLeft = new GooseMoveHorizontal();
        buttonRight = new GooseMoveHorizontal();
    }

    // Update is called once per frame
    override protected void Update()
    {
        HandleInput();
    }
    public override void HandleInput()
    {
        // While left arrow key is held
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left");
            buttonLeft.Execute(rb, buttonLeft);

        }

        // While right arrow key is held
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
            buttonRight.Execute(rb, buttonRight);
        }
    }
}
