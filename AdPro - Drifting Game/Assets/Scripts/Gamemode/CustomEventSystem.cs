using System;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action onLapStart;
    public void LapStart()
    {
        if (onLapStart != null)
        {
            onLapStart();
        }
    }

    public event Action onLapEnd;
    public void LapEnd()
    {
        if (onLapEnd != null)
        {
            onLapEnd();
        }
    }
}
