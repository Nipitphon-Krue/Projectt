using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Action OnTargetHit;

    private void Start()
    {
        RandomizePosition();
    }

    public void Hit()
    {
        RandomizePosition();
        NotifyTargetHit();
    }

    private void RandomizePosition()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }

    private void NotifyTargetHit()
    {
        OnTargetHit?.Invoke();
    }
}
