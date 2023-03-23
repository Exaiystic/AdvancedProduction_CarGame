using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetArm;
    [SerializeField] private float _cameraStiffness = 0.1f;
    //[SerializeField] private Vector3 _offset = new Vector3(0f, 3f, 7.5f);

    private Vector3 vel = Vector3.zero;

    private void Awake()
    {
        if (_target == null) { _target = GameObject.FindGameObjectWithTag("Player").transform; }

        if (_targetArm == null) { _targetArm = GameObject.Find("FollowPoint").transform; }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = _targetArm.position;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref vel, _cameraStiffness);

        //Old version
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, _cameraStiffness);
        //transform.position = smoothedPos;

        transform.LookAt(_target);
    }
}
