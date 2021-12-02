using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasing : Command
{
    public Erasing(Transform cubeAffected, Color previousColor) : base(cubeAffected, previousColor){}

    public override void Do()
    {
        CubeAffected.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public override void Undo()
    {
        CubeAffected.GetComponent<MeshRenderer>().material.color = PreviousColor;
    }
}
