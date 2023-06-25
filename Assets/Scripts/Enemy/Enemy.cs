using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    [Header("Components")]
    [SerializeField] private Image enemyButtonImage;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Animation anim;
    [SerializeField] private TextMeshProUGUI nameText;
    
    private int currentHp;

    public event Action OnDefeated;

    public void SetData(EnemyData data)
    {
        this.data = data;

        currentHp = data.GetMaxHp(GameManager.Instance.CurrentLevel);
        enemyButtonImage.sprite = data.sprite;

        nameText.text = data.enemyName;
    }
    
    public void Damage(int amount)
    {
        if (currentHp <= 0) return;

        currentHp = Mathf.Clamp(currentHp - amount, 0, data.GetMaxHp(GameManager.Instance.CurrentLevel));
        healthBarFill.fillAmount = (float)currentHp / (float)data.GetMaxHp(GameManager.Instance.CurrentLevel);

        anim.Stop();
        anim.Play();

        if (currentHp <= 0) {
            Defeated();
        }
    }

    public int GetGoldToGive() 
    {
        return data.GetGoldToGive(GameManager.Instance.CurrentLevel);
    }

    private void Defeated()
    {
        OnDefeated?.Invoke();
    }
}
