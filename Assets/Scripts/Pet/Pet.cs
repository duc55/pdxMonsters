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
        if (Time.time - lastAttackTime >= data.GetTimeBetweenAttacks(attackSpeedLevel)) {
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

    private void Attack()
    {
        anim.Stop();
        anim.Play();

        EnemyManager.Instance.CurrentEnemy.Damage(data.GetAttackPower(attackPowerLevel));
    }
}
