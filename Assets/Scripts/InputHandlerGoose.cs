using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerGoose : InputHandler
{
    protected override void Start()
    {
        base.Start();
        // Bind keys with commands
        buttonLeft = new GooseCommands.MoveHorizontal();
        buttonRight = new GooseCommands.MoveHorizontal();
    }

    // Update is called once per frame
    protected override void Update()
    {
        HandleInput();
    }

    // Check if key is pressed/held, then execute command
    protected override void HandleInput()
    {
        // While left arrow key is held
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonLeft.Execute(rb, buttonLeft);
        }

        // While right arrow key is held
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonRight.Execute(rb, buttonRight);
        }
    }
}
