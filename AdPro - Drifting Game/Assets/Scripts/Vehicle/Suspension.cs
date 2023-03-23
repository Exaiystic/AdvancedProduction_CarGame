using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    [Header("Wheels")]
    [SerializeField] private List<GameObject> wheels;
    [SerializeField] private float wheelRadius;

    [Header("Suspension")]
    [SerializeField] private float suspensionMaxExtention = 1f;
    [SerializeField] private float springMultiplier = 25f;

    [Header("Other")]
    [SerializeField] private Rigidbody rb;

    private float maxExtention;

    private void Awake()
    {
        if (rb == null)
        { rb = GetComponent<Rigidbody>(); }
    }

    private void Start()
    {
        maxExtention = suspensionMaxExtention + wheelRadius;
    }

    private void FixedUpdate()
    {
        foreach (GameObject wheel in wheels)
        {
            //Extend trace for wheels[i]
            if (Physics.Raycast(wheel.transform.position, wheel.transform.TransformDirection(Vector3.down), out RaycastHit hitData, maxExtention))
            {
                Debug.DrawRay(wheel.transform.position, wheel.transform.TransformDirection(Vector3.down) * hitData.distance, Color.red);
                //Apply upwards force to body at point of wheels - force should be equal to the amount of distance uncovered in trace
                float forceToApply = maxExtention - hitData.distance;
                Debug.DrawRay(wheel.transform.position, wheel.transform.TransformDirection(Vector3.up) * forceToApply * springMultiplier, Color.yellow);
                rb.AddForceAtPosition(Vector3.up * forceToApply * springMultiplier, wheel.transform.position, ForceMode.Acceleration);
            }
            else
            {
                Debug.DrawRay(wheel.transform.position, wheel.transform.TransformDirection(Vector3.down) * maxExtention, Color.green);
            }

            //Update wheel position
        }
    }

    public List<GameObject> GetWheels()
    {
        return wheels;
    }

    public float ReturnWheelRadius()
    {
        return wheelRadius;
    }

    public Vector3 GetContactPoints(GameObject wheel)
    {
        if (Physics.Raycast(wheel.transform.position, wheel.transform.TransformDirection(Vector3.down), out RaycastHit hitData, maxExtention))
        {
            return hitData.point;
        } else
        {
            return new Vector3(wheel.transform.position.x, wheel.transform.position.y - maxExtention, wheel.transform.position.z);
        }

        //Vector3 point = new Vector3(wheel.transform.position.x, wheel.transform.position.y - hitData.distance, wheel.transform.position.z);
    }
}
