using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public static int Score { get; private set; }

    private void OnEnable()
    {
        Target.OnTargetHit += HandleTargetHit;
    }

    private void OnDisable()
    {
        Target.OnTargetHit -= HandleTargetHit;
    }

    private void HandleTargetHit()
    {
        IncreaseScore();
        UpdateScoreText();
    }

    private void IncreaseScore()
    {
        Score++;
    }

    private void UpdateScoreText()
    {
        text.text = $"Score: {Score}";
    }
}
