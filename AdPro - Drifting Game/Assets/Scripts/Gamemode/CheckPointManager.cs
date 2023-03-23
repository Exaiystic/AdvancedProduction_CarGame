using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [Header("Checkpoints")]
    [SerializeField] private List<Checkpoint> checkPointOrder;

    private int activeCheckpointIndex = 0;

    private void Start()
    {
        foreach (Checkpoint checkpoint in checkPointOrder)
        {
            checkpoint.ToggleActive(false);
        }

        checkPointOrder[0].ToggleActive(true);
        activeCheckpointIndex = 0;
}
    
    public void CheckpointHit()
    {
        Debug.Log("Checkpoint Hit");

        checkPointOrder[activeCheckpointIndex].ToggleActive(false);
        activeCheckpointIndex++;
        checkPointOrder[activeCheckpointIndex].ToggleActive(true);
    }
}
