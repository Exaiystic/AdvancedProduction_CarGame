using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Engine : MonoBehaviour
{
    [Header("Engine")]
    [SerializeField] private float force = 2500;
    [SerializeField] private Transform forcePoint;

    [Header("References")]
    [SerializeField] private Suspension suspensionScript;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody rb;

    private List<GameObject> wheels = new List<GameObject>();

    private bool engineOn = false;
    private float throttleInput;
    private Driving driving;

    private void Awake()
    {
        if (playerInput == null)
        { playerInput = GetComponent<PlayerInput>(); }

        if (rb == null)
        { rb = GetComponent<Rigidbody>(); }

        if (suspensionScript == null)
        { suspensionScript = GetComponent<Suspension>(); }
    }

    private void Start()
    {
        driving = new Driving();
        driving.PlayerSteering.Enable();

        driving.PlayerSteering.Throttle.performed += ThrottleInput;
        CustomEventSystem.current.onLapStart += EnableEngine;
        CustomEventSystem.current.onLapEnd += DisableEngine;

        wheels.AddRange(suspensionScript.GetWheels());
    }

    private void EnableEngine()
    {
        engineOn = true;
    }

    private void DisableEngine()
    {
        engineOn = false;
    }

    private void ThrottleInput(InputAction.CallbackContext obj)
    {
        throttleInput = obj.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Vector3 forceDir = new Vector3(transform.forward.x, 0, transform.forward.z);

        /* foreach (GameObject wheel in wheels)
        {
            Vector3 forceDir = new Vector3(transform.forward.x, 0, transform.forward.z);
            
            rb.AddForceAtPosition((forceDir * force) * throttleInput, suspensionScript.GetContactPoints(wheel));
            Debug.DrawRay(suspensionScript.GetContactPoints(wheel), (forceDir * force) * throttleInput);
        } */

        if (engineOn)
        {
            rb.AddForceAtPosition((forceDir * force) * throttleInput, forcePoint.position);
        }
        Debug.DrawRay(forcePoint.position, (forceDir * force) * throttleInput);
    }
}
