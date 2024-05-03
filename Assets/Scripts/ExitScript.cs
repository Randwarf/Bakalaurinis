using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitScript : MonoBehaviour
{
    float clickedCount = 0;
    float clickTime = 0;
    const float CLICK_DELAY = 0.5f;

    public bool QuitToStart = false;

    public InputActionReference ExitButton;

    void Start()
    {
        ExitButton.action.performed += Exit;
    }

    public void Exit(InputAction.CallbackContext context)
    {
        if (QuitToStart)
        {
            Level.GetInstance().TeleportToSpawn();
        }
        else
        {
            Application.Quit();
        }
    }
}
