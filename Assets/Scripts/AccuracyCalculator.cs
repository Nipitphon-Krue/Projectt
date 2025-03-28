using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccuracyCalculator : MonoBehaviour
{
    [SerializeField] private TMP_Text accuracyText;

    private void OnEnable()
    {
        Timer.OnGameEnded += CalculateAccuracy;
    }

    private void OnDisable()
    {
        Timer.OnGameEnded -= CalculateAccuracy;
    }

    private void CalculateAccuracy()
    {
        int score = ScoreCounter.Score;
        int misses = MissCounter.Misses;
        float accuracy = (float)score / (score + misses) * 100f;
        accuracyText.text = $"Accuracy: {accuracy:0}%";
    }
}
