using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] private PetData data;

    [Header("Components")]
    [SerializeField] private Image petImage;
    [SerializeField] private Animation anim;

    private float lastAttackTime;
    private int attackPowerLevel = 0;
    private int attackSpeedLevel = 0;

    private void Update()
    {
        if (Time.time - lastAttackTime >= GetTimeBetweenAttacks()) {
            lastAttackTime = Time.time;

            if (EnemyManager.Instance.CurrentEnemy == null) return;

            Attack();
        }
    }

    public void SetData(PetData data)
    {
        this.data = data;

        petImage.sprite = data.sprite;
    }

    public void ShowInfo()
    {
        PetInfoManager.Instance.ShowPetInfo(this);
    }

    public string GetPetName()
    {
        return data.petName;
    }

    public int GetAttackPower()
    {
        return data.GetAttackPower(attackPowerLevel);
    }

    public float GetTimeBetweenAttacks()
    {
        return data.GetTimeBetweenAttacks(attackSpeedLevel);
    }

    public int GetPowerUpCost()
    {
        const int baseCost = 10;
        return (attackPowerLevel + 1) * baseCost;
    }

    public int GetSpeedUpCost()
    {
        const int baseCost = 15;
        return (attackSpeedLevel + 1) * baseCost;
    }

    public void LevelUpPower()
    {
        attackPowerLevel++;
    }

    public void LevelUpSpeed()
    {
        attackSpeedLevel++;
    }

    private void Attack()
    {
        anim.Stop();
        anim.Play();

        EnemyManager.Instance.CurrentEnemy.Damage(GetAttackPower());
    }
}
