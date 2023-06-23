using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;

    [SerializeField] TextMeshProUGUI goldText;

    public Sprite[] backgrounds;
    private int currentBackground;
    private int enemiesUntilBackgroundChange;
    public Image backgroundImage;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        enemiesUntilBackgroundChange = 5;
    }

    public void AddGold(int amount) 
    {
        gold += amount;
        goldText.text = "Gold: " + gold.ToString();
    }

    public void TakeGold(int amount) 
    {
        gold -= amount;
        goldText.text = "Gold: " + gold.ToString();
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
