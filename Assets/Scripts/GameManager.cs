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

    private int currentBackground;
    private int enemiesUntilBackgroundChange;

    private void Awake()
    {
        Instance = this;
        enemiesUntilBackgroundChange = 5;
    }

    public void AddGold(int amount) 
    {
        Gold += amount;
        goldText.text = "Gold: " + Gold.ToString();
    }

    public void TakeGold(int amount) 
    {
        Gold -= amount;
        goldText.text = "Gold: " + Gold.ToString();
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
}
