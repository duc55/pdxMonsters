using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int currentHp;
    [SerializeField] private int maxHp;
    [SerializeField] private int goldToGive;
    [SerializeField] private Image healthBarFill;
    public Animation anim;

    public void Damage()
    {
        currentHp--;
        healthBarFill.fillAmount = (float)currentHp / (float)maxHp;

        anim.Stop();
        anim.Play();

        if (currentHp <= 0) {
            Defeated();
        }
    }

    public void Defeated()
    {
        GameManager.Instance.AddGold(goldToGive);
        EnemyManager.Instance.DefeatEnemy(gameObject);
    }
}
