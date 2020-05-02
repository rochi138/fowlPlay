using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : MonoBehaviour

{
    // Char we controlling with keys
    public Transform charTrans; 

    // keys needed
    private Command buttonLeft, buttonRight;


    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            buttonLeft = new MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            buttonRight = new MoveRight();
        }

    }
}
