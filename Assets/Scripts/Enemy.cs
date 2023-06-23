using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHp;
    [SerializeField] private int maxHp;
    [SerializeField] private int goldToGive;

    [Header("Components")]
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Animation anim;

    public event Action OnDefeated;

    public void Damage(int amount)
    {
        currentHp = Mathf.Clamp(currentHp - amount, 0, maxHp);
        healthBarFill.fillAmount = (float)currentHp / (float)maxHp;

        anim.Stop();
        anim.Play();

        if (currentHp <= 0) {
            Defeated();
        }
    }

    public void Defeated()
    {
        OnDefeated?.Invoke();
        GameManager.Instance.AddGold(goldToGive);
        EnemyManager.Instance.DefeatEnemy(gameObject);
    }
}
