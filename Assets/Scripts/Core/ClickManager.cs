using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private List<float> autoClickersLastTime = new List<float>();
    [SerializeField] private int autoClickerPrice = 10;

    [Header("Components")]
    [SerializeField] private TextMeshProUGUI quantityText;

    private void Update()
    {
        for (int i = 0; i < autoClickersLastTime.Count; i++) {
            if (Time.time - autoClickersLastTime[i] >= 1.0f) {
                autoClickersLastTime[i] = Time.time;

                if (EnemyManager.Instance.CurrentEnemy == null) continue;

                int damage = 1;
                EnemyManager.Instance.CurrentEnemy.Damage(damage);
            }
        }
    }

    public void OnBuyAutoClicker()
    {
        if (GameManager.Instance.Gold >= autoClickerPrice) {
            GameManager.Instance.TakeGold(autoClickerPrice);
            autoClickersLastTime.Add(Time.time);

            quantityText.text = "x " + autoClickersLastTime.Count.ToString();
        }
    }
}
