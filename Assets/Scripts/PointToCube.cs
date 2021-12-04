using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToCube : MonoBehaviour
{
    private Stack<Command> Commands = new Stack<Command>();

    private Stack<Command> RedoCommands = new Stack<Command>();

    private Color _colorSelected = Color.white;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Image previewColor;

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

    public void GetNewColor()
    {
        _colorSelected = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        previewColor.color = _colorSelected;
    }
}
