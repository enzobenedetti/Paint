using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public GameObject pixelPrefab;
    private int _width = 25;
    private int _height = 15;

    public Transform cubeHolder;
    public GameObject linePrefab;

    public void ChangeWidth(string width)
    {
        _width = int.Parse(width);
        foreach (Transform cube in cubeHolder)
        {
            Destroy(cube.gameObject);
        }
        for (int y = 1; y <= _height; y++)
        {
            GameObject line = Instantiate(linePrefab, new Vector3(0, 0, y - _height/2), Quaternion.identity, cubeHolder);
            line.name = "line " + y;
            for (int x = 1; x <= _width; x++)
            {
                GameObject cube = Instantiate(pixelPrefab, line.transform);
                cube.transform.localPosition = new Vector3(x - _width / 2, 0, 0);
                cube.name = "Cube " + x;
            }
        }
    }

    public void ChangeHeight(string height)
    {
        _height = int.Parse(height) + 1;
        foreach (Transform cube in cubeHolder)
        {
            Destroy(cube.gameObject);
        }
        for (int y = 1; y < _height; y++)
        {
            GameObject line = Instantiate(linePrefab, new Vector3(0, 0, y - _height/2), Quaternion.identity, cubeHolder);
            line.name = "line " + y;
            for (int x = 0; x < _width; x++)
            {
                GameObject cube = Instantiate(pixelPrefab, line.transform);
                cube.transform.localPosition = new Vector3(x - _width / 2, 0, 0);
                cube.name = "Cube " + x;
            }
        }
    }
}
