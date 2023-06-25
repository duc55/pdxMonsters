using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance;

    public bool IsMouseOverEnemy { get; private set; } = false;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one ClickManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetMouseOverEnemy(bool isOver)
    {
        IsMouseOverEnemy = isOver;
    }
}
