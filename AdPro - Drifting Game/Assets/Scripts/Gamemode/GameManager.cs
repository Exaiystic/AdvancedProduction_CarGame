using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Countdown")]
    [SerializeField] private float startCountdownLength;
    [SerializeField] private TMP_Text countdownText;

    private bool countdownActive = true;
    private float countdownCurrentTime;

    [Header("Stopwatch")]
    [SerializeField] private TMP_Text stopwatchText;
    [SerializeField] private TMP_Text postGameStopwatchText;

    private bool stopwatchActive = false;
    private float stopwatchCurrentTime = 0f;

    [Header("UI")]
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private GameObject postGameUI;

    private void Start()
    {
        countdownCurrentTime = startCountdownLength;

        CustomEventSystem.current.onLapEnd += StopTimer;
        CustomEventSystem.current.onLapEnd += PostGame;

        if (inGameUI != null)
            { inGameUI.SetActive(true); }

        if (postGameUI != null)
            { postGameUI.SetActive(false); }
    }

    private void Update()
    {
        Countdown();

        Stopwatch();
    }

    private void StartCountdown()
    {
        countdownActive = true;
    }

    private void StartTimer()
    {
        stopwatchActive = true;
    }

    private void StopTimer()
    {
        stopwatchActive = false;
    }

    private void Countdown()
    {
        if (countdownCurrentTime > 0f && countdownActive)
        {
            //Updating countdown text
            TimeSpan time = TimeSpan.FromSeconds(countdownCurrentTime);
            countdownText.text = time.Seconds.ToString();

            //Counting down
            countdownCurrentTime -= Time.deltaTime;
        }
        else if (countdownActive)
        {
            countdownText.text = "";
            countdownActive = false;

            CustomEventSystem.current.LapStart();
            StartTimer();
        }
    }

    private void Stopwatch()
    {
        if (stopwatchActive)
        {
            stopwatchCurrentTime += Time.deltaTime;

            stopwatchText.text = FormatTime(stopwatchCurrentTime);
        }
    }

    private String FormatTime(float timeToFormat)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeToFormat);
        return time.ToString(@"mm\:ss\:fff");
    }

    private void PostGame()
    {
        if (inGameUI != null)
            { inGameUI.SetActive(false); }

        if (postGameUI != null)
            { postGameUI.SetActive(true); }

        if (postGameStopwatchText != null)
            { postGameStopwatchText.text = FormatTime(stopwatchCurrentTime); }
    }
}
