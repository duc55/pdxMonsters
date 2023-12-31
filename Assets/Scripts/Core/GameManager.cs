using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Gold { get; private set; } = 0;
    public int CurrentLevel { get; private set; } = 0;

    [SerializeField] int enemiesPerLevel = 15;

    [Header("Components")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private EnemyManager enemyManager;

    private int enemiesDefeated = 0;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one GameManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        enemyManager.OnEnemyDefeated += EnemyManager_OnEnemyDefeated;
    }

    private void OnDisable()
    {
        enemyManager.OnEnemyDefeated -= EnemyManager_OnEnemyDefeated;
    }

    public void AddGold(int amount) 
    {
        Gold += amount;
        UpdateGoldText();
    }

    public void TakeGold(int amount) 
    {
        Gold -= amount;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = Gold.ToString();
    }

    private void EnemyManager_OnEnemyDefeated(int goldDropped)
    {
        AddGold(goldDropped);
        BackgroundManager.Instance.BackgroundCheck();

        enemiesDefeated++;

        if (enemiesDefeated % enemiesPerLevel == 0) {
            CurrentLevel++;
        } 
    }
}
