using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action OnGameEnded;
    public static bool GameEnded { get; private set; }

    [SerializeField] private TMP_Text timerText;

    private float endTime;

    private const float gameTime = 10f;

    private void Start()
    {
        InitializeTimer();
    }

    private void Update()
    {
        if (GameEnded)
            return;

        UpdateTimer();
    }

    private void InitializeTimer()
    {
        GameEnded = false;
        endTime = Time.time + gameTime;
    }

    private void UpdateTimer()
    {
        float timeLeft = endTime - Time.time;

        if (timeLeft <= 0)
        {
            EndGame();
            timeLeft = 0;
        }

        DisplayTimeLeft(timeLeft);
    }

    private void EndGame()
    {
        GameEnded = true;
        OnGameEnded?.Invoke();
    }

    private void DisplayTimeLeft(float timeLeft)
    {
        timerText.text = $"Time Left: {timeLeft.ToString("0.0")}";
    }
}
