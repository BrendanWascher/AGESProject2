using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckControllerConnected : MonoBehaviour
{
    [SerializeField]
    private Text keyboard;

    [SerializeField]
    private Text controller;

    private string[] controllers;
    private bool isControllerConnected = false;

	void Start ()
    {
        controllers = Input.GetJoystickNames();
        if (controllers.Length > 1)
            isControllerConnected = true;

        UpdateText();

	}

    private void UpdateText()
    {
        if(isControllerConnected)
        {
            controller.enabled = true;
            keyboard.enabled = false;
        }
        else
        {
            keyboard.enabled = true;
            controller.enabled = false;
        }
    }

}
