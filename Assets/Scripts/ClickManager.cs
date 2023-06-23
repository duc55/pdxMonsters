using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    public List<float> autoClickersLastTime = new List<float>();
    public int autoClickerPrice = 10;

    public TextMeshProUGUI quantityText;

    private void Update()
    {
        for (int i = 0; i < autoClickersLastTime.Count; i++) {
            if (Time.time - autoClickersLastTime[i] >= 1.0f) {
                autoClickersLastTime[i] = Time.time;
                EnemyManager.Instance.currentEnemy.Damage();
            }
        }
    }

    public void OnBuyAutoClicker()
    {
        if (GameManager.Instance.gold >= autoClickerPrice) {
            GameManager.Instance.TakeGold(autoClickerPrice);
            autoClickersLastTime.Add(Time.time);

            quantityText.text = "x " + autoClickersLastTime.Count.ToString();
        }
    }
}
