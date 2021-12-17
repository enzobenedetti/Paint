using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToCube : MonoBehaviour
{
    private Stack<Stack<Command>> Commands = new Stack<Stack<Command>>();
    private Stack<Command> RunningCommands = new Stack<Command>();

    private Stack<Stack<Command>> RedoCommands = new Stack<Stack<Command>>();

    private Color _colorSelected = Color.gray;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image previewColor;

    private Transform _lastCubeColored;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Paint"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Cube") && hit.transform != _lastCubeColored)
                {
                    Command command = new Coloring(_colorSelected,
                        hit.transform.GetComponent<MeshRenderer>().material.color, hit.transform);
                    command.Do();
                    RunningCommands.Push(command);
                    if (RedoCommands.Count > 0) RedoCommands.Clear();
                    _lastCubeColored = hit.transform;
                }
            }
        }
        if (Input.GetButtonUp("Paint"))
        {
            if (RunningCommands.Count > 0) Commands.Push(RunningCommands);
            RunningCommands = new Stack<Command>();
        }
        
        if (Input.GetButton("Erase"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Cube") && hit.transform.GetComponent<MeshRenderer>().material. color != Color.white)
                {
                    Command command = new Erasing(hit.transform, hit.transform.GetComponent<MeshRenderer>().material.color);
                    command.Do();
                    RunningCommands.Push(command);
                    if (RedoCommands.Count > 0) RedoCommands.Clear();
                }
            }
        }

        if (Input.GetButtonUp("Erase"))
        {
            if (RunningCommands.Count > 0) Commands.Push(RunningCommands);
            RunningCommands = new Stack<Command>();
        }

        if (Input.GetButtonDown("Undo"))
        {
            Debug.Log(Commands.Count);
            if (Commands.Count == 0) return;
            Stack<Command> commands = Commands.Pop();
            foreach (Command command in commands)
            {
                command.Undo();
            }
            RedoCommands.Push(commands);
        }

        if (Input.GetButtonDown("Redo"))
        {
            if (RedoCommands.Count == 0) return;
            Stack<Command> commands = RedoCommands.Pop();
            foreach (Command command in commands)
            {
                command.Do();
            }
            Commands.Push(commands);
        }
    }

    public void GetNewColor()
    {
        _colorSelected = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        previewColor.color = _colorSelected;
    }
}
