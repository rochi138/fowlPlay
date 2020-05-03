using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for player commands.
/// </summary>
public abstract class Command
{
    public abstract void Execute(Rigidbody2D rigidbody, Command command);

    public virtual void Move(Rigidbody2D rigidbody) { }

}