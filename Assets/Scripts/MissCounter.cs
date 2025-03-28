using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public static int Misses { get; private set; }

    private void OnEnable()
    {
        TargetShooter.OnTargetMissed += HandleTargetMissed;
    }

    private void OnDisable()
    {
        TargetShooter.OnTargetMissed -= HandleTargetMissed;
    }

    private void HandleTargetMissed()
    {
        IncrementMissCount();
        UpdateMissText();
    }

    private void IncrementMissCount()
    {
        Misses++;
    }

    private void UpdateMissText()
    {
        text.text = $"Misses: {Misses}";
    }
}
