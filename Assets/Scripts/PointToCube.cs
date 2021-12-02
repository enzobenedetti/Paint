using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCube : MonoBehaviour
{
    private Stack<Command> Commands = new Stack<Command>();

    private Stack<Command> RedoCommands = new Stack<Command>();

    private Color _colorSelected = Color.blue;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Cube"))
                {
                    Command command = new Coloring(_colorSelected,
                        hit.transform.GetComponent<MeshRenderer>().material.color, hit.transform);
                    command.Do();
                    Commands.Push(command);
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Cube") && hit.transform.GetComponent<MeshRenderer>().material. color != Color.white)
                {
                    Command command = new Erasing(hit.transform, hit.transform.GetComponent<MeshRenderer>().material.color);
                    command.Do();
                    Commands.Push(command);
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (Commands.Count == 0) return;
            Command command = Commands.Pop();
            command.Undo();
        }
    }

    public void GetNewColor(Material color)
    {
        _colorSelected = color.color;
    }
}
