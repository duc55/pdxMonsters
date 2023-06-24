using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHp;

    [SerializeField] private EnemyData data;

    [Header("Components")]
    [SerializeField] private Image enemyButtonImage;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Animation anim;

    public event Action OnDefeated;

    public void SetData(EnemyData data)
    {
        this.data = data;

        currentHp = data.maxHp;
        enemyButtonImage.sprite = data.sprite;

    }
    
    public void Damage(int amount)
    {
        if (currentHp <= 0) return;

        currentHp = Mathf.Clamp(currentHp - amount, 0, data.maxHp);
        healthBarFill.fillAmount = (float)currentHp / (float)data.maxHp;

        anim.Stop();
        anim.Play();

        if (currentHp <= 0) {
            Defeated();
        }
    }

    public int GetGoldToGive() 
    {
        return data.goldToGive;
    }

    private void Defeated()
    {
        OnDefeated?.Invoke();
    }
}
