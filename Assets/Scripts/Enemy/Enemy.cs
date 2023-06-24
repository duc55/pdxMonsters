using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    [SerializeField] private int currentHp;

    [Header("Components")]
    [SerializeField] private Image enemyButtonImage;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Animation anim;
    [SerializeField] private TextMeshProUGUI nameText;

    public event Action OnDefeated;

    public void SetData(EnemyData data)
    {
        this.data = data;

        currentHp = data.maxHp;
        enemyButtonImage.sprite = data.sprite;

        nameText.text = data.enemyName;
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
