using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public GameObject pixelPrefab;
    public static int Width = 25;
    public static int Height = 15;

    public Transform cubeHolder;
    public GameObject linePrefab;

    public void ChangeWidth(string width)
    {
        Width = int.Parse(width);
        foreach (Transform cube in cubeHolder)
        {
            Destroy(cube.gameObject);
        }
        for (int y = 1; y <= Height; y++)
        {
            GameObject line = Instantiate(linePrefab, new Vector3(0, 0, y - Height/2), Quaternion.identity, cubeHolder);
            line.name = "line " + y;
            for (int x = 1; x <= Width; x++)
            {
                GameObject cube = Instantiate(pixelPrefab, line.transform);
                cube.transform.localPosition = new Vector3(x - Width / 2, 0, 0);
                cube.name = "Cube " + x;
            }
        }
    }

    public void ChangeHeight(string height)
    {
        Height = int.Parse(height) + 1;
        foreach (Transform cube in cubeHolder)
        {
            Destroy(cube.gameObject);
        }
        for (int y = 1; y < Height; y++)
        {
            GameObject line = Instantiate(linePrefab, new Vector3(0, 0, y - Height/2), Quaternion.identity, cubeHolder);
            line.name = "line " + y;
            for (int x = 0; x < Width; x++)
            {
                GameObject cube = Instantiate(pixelPrefab, line.transform);
                cube.transform.localPosition = new Vector3(x - Width / 2, 0, 0);
                cube.name = "Cube " + x;
            }
        }
    }
}
