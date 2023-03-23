using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Steering : MonoBehaviour
{
    [Header("Steering")]
    [SerializeField] private float torque;
    [SerializeField] private float maxTorqueForwardThreshold = 3f;
    [SerializeField] private float maxTorqueBackwardThreshold = -3f;

    [Header("Wheels")]
    [SerializeField] private GameObject[] steeringWheels;

    [Header("References")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody rb;
    
    private Driving driving;

    private float forwardVelocity;
    private float possibleTorque;
    private float steeringInput = 0f;

    private void Awake()
    {
        if (rb == null)
        { rb = GetComponent<Rigidbody>(); }
    }

    private void Start()
    {
        driving = new Driving();
        driving.PlayerSteering.Enable();

        driving.PlayerSteering.Steering.performed += SteeringInput;
    }

    private void SteeringInput(InputAction.CallbackContext obj)
    {
        steeringInput = obj.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        forwardVelocity = transform.InverseTransformDirection(rb.velocity).z;

        if (forwardVelocity >= maxTorqueForwardThreshold)
        {
            possibleTorque = 1f;
        } else
        {
            possibleTorque = forwardVelocity / maxTorqueForwardThreshold;
        }

        rb.AddTorque(-steeringInput * (torque * possibleTorque) * transform.up);
    }
}
