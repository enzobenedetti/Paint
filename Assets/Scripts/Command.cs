using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{

    protected Transform CubeAffected;
    protected Color PreviousColor;

    protected Command(Transform cubeAffected, Color previousColor)
    {
        CubeAffected = cubeAffected;
        PreviousColor = previousColor;
    }

    public abstract void Do();

    public abstract void Undo();
}
