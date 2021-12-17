using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject saveInstructions;
    private bool saveOn;
    private float timeButton = -20f;
    private float timeShown = 3f;

    public void ShowHowToSave()
    {
        saveInstructions.SetActive(true);
        timeButton = Time.time;
    }

    private void Update()
    {
        if (Time.time >= timeButton + timeShown)
        {
            saveInstructions.SetActive(false);
        }
    }
}
