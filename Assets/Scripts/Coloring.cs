using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloring : Command
{
    
    protected Color NewColor;

    public Coloring(Color newColor, Color previousColor, Transform cubeAffected) : base(cubeAffected, previousColor)
    {
        NewColor = newColor;
    }
    
    public override void Do()
    {
        CubeAffected.GetComponent<MeshRenderer>().material.color = NewColor;
    }

    public override void Undo()
    {
        CubeAffected.GetComponent<MeshRenderer>().material.color = PreviousColor;
    }
}
