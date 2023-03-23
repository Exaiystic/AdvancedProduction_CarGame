using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private enum checkPointType
    {
        Start,
        Checkpoint,
        FinishLine
    };

    [SerializeField] private checkPointType type;

    [Header("Functionality References")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private CheckPointManager checkPointManager;

    [Header("Visual Assets")]
    [SerializeField] private GameObject startAssets;
    [SerializeField] private GameObject finishAssets;

    private bool isActive = false;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (spawnPoint == null)
        {
            spawnPoint = transform.Find("SpawnPoint");
        }

        if (startAssets == null)
        {
            Transform temp = gameObject.transform.Find("StartAssets");
            startAssets = temp.gameObject;
        }

        if (finishAssets == null)
        {
            Transform temp = gameObject.transform.Find("FinishAssets");
            finishAssets = temp.gameObject;
        }

        if (checkPointManager == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            checkPointManager = gm.GetComponent<CheckPointManager>();
        }
    }

    private void Start()
    {
        if (type == checkPointType.Start)
        {
            player.transform.position = spawnPoint.position;
        } else
        {
            startAssets.SetActive(false);
        }

        if (type != checkPointType.FinishLine)
        {
            finishAssets.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            if (isActive)
            {
                if (type != checkPointType.FinishLine)
                {
                    if (checkPointManager != null)
                    {
                        checkPointManager.CheckpointHit();
                    }
                } else
                {
                    CustomEventSystem.current.LapEnd();
                }
            }
        }
    }

    public void ToggleActive(bool newState)
    {
        isActive = newState;
    }
}
