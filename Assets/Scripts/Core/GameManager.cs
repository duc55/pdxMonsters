using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public int Gold { get; private set; } = 0;

    [SerializeField] private Sprite[] backgrounds;

    [Header("Components")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private EnemyManager enemyManager;

    private int currentBackground;
    private int enemiesUntilBackgroundChange;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one GameManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        enemiesUntilBackgroundChange = 5;
    }

    private void OnEnable()
    {
        enemyManager.OnEnemyDefeated += AddGold;
    }

    private void OnDisable()
    {
        enemyManager.OnEnemyDefeated -= AddGold;
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

    public void BackgroundCheck()
    {
        enemiesUntilBackgroundChange--;
        if (enemiesUntilBackgroundChange == 0) {
            enemiesUntilBackgroundChange = 5;
            currentBackground++;

            if (currentBackground == backgrounds.Length) {
                currentBackground = 0;
            }

            backgroundImage.sprite = backgrounds[currentBackground];
        }
    }

    private void UpdateGoldText()
    {
        goldText.text = Gold.ToString();
    }
}
