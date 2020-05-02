using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Command : MonoBehaviour
{
    // how far character moves
    protected float moveDistance = 1f;

    public abstract void Execute(Transform charTrans, Command command);

    public virtual void Move(Transform charTrans) { }

}

// -- Child classes -- //
    
public class MoveForward : Command
{
    public override void Execute(Transform charTrans, Command command)
    {
        Move(charTrans);
    }

    public override void Move(Transform charTrans)
    {
        charTrans.Translate(charTrans.forward * moveDistance);
    }
}

public class MoveBackward : Command
{
    public override void Execute(Transform charTrans, Command command)
    {
        Move(charTrans);
    }

    public override void Move(Transform charTrans)
    {
        charTrans.Translate(-charTrans.forward * moveDistance);
    }
}


