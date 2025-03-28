using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private void OnEnable()
    {
        Timer.OnGameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        Timer.OnGameEnded -= OnGameEnded;
    }

    private void OnGameEnded()
    {
        ShowEndPanel();
        UnlockCursor();
    }

    private void ShowEndPanel()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
