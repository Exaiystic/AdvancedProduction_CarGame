using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalSuspension : MonoBehaviour
{
    [Header("Settings - Wheel References")]
    [SerializeField] private Transform[] wheels;

    [Header("Settings - General")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float suspensionMaxExtention;
    [SerializeField] private float springMultiplier = 1f;

    private RaycastHit[] hits = new RaycastHit[4]; 

    private void Awake()
    {
        if (rb == null)
        { rb = GetComponent<Rigidbody>(); }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            ApplyF(wheels[i], hits[i]);
        }
    }

    private void ApplyF(Transform wheel, RaycastHit hit)
    {
        if (Physics.Raycast(wheel.position, -wheel.up, out hit))
        {
            float force = Mathf.Abs(1 / hit.point.y - wheel.position.y);
            rb.AddForceAtPosition(force * springMultiplier * transform.up, wheel.position, ForceMode.Acceleration);
        }
    }
}
