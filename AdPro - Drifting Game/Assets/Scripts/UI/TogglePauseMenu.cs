using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TogglePauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;

    private Driving driving;
    private bool isActive = false;

    private void Start()
    {
        driving = new Driving();
        driving.PlayerSteering.Enable();

        driving.PlayerSteering.Pause.performed += PauseInput;

        pauseUI.SetActive(false);
        isActive = false;
    }

    private void PauseInput(InputAction.CallbackContext obj)
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        if (isActive)
        { 
            pauseUI.SetActive(false);
            isActive = false;
            Time.timeScale = 1f;
        }
        else
        { 
            pauseUI.SetActive(true);
            isActive = true;
            Time.timeScale = 0f;
        }
    }
}
