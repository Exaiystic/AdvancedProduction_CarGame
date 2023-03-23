using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWheel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mesh;
    [SerializeField] private Suspension suspensionScript;

    private float wheelRadius;

    private void Awake()
    {
        if (suspensionScript == null)
        {
            GameObject vehicle = GameObject.FindGameObjectWithTag("Player");
            suspensionScript = vehicle.GetComponent<Suspension>();
        }
    }

    private void Start()
    {
        wheelRadius = suspensionScript.ReturnWheelRadius();
    }

    private void Update()
    {
        wheelRadius = suspensionScript.ReturnWheelRadius();

        if (mesh != null)
        {
            Vector3 wheelPos = new Vector3(suspensionScript.GetContactPoints(gameObject).x, (suspensionScript.GetContactPoints(gameObject).y + wheelRadius), suspensionScript.GetContactPoints(gameObject).z);
            mesh.transform.position = wheelPos;
        }
    }
}
