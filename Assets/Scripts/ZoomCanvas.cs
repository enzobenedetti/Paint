using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCanvas : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0f)
        {
            Camera.orthographicSize -= scroll;
            
        }
    }
}
