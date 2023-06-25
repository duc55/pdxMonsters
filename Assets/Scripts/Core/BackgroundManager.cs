using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;

    [SerializeField] private int enemiesPerBackground = 5;
    [SerializeField] private Sprite[] backgrounds;

    [Header("Components")]
    [SerializeField] private Image backgroundImage;

    private int currentBackground;
    private int enemiesUntilBackgroundChange;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one BackgroundManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        enemiesUntilBackgroundChange = enemiesPerBackground;
    }

    public bool BackgroundCheck()
    {
        enemiesUntilBackgroundChange--;

        if (enemiesUntilBackgroundChange == 0) {
            enemiesUntilBackgroundChange = enemiesPerBackground;
            currentBackground++;

            if (currentBackground == backgrounds.Length) {
                currentBackground = 0;
            }

            backgroundImage.sprite = backgrounds[currentBackground];

            return true;
        }

        return false;
    }
}
