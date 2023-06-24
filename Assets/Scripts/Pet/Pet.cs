using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] private PetData data;

    private int attackPower = 1;
    private float timeBetweenAttacks = 1.0f;
    private float lastAttackTime;

    [Header("Components")]
    [SerializeField] private Image petImage;
    [SerializeField] private Animation anim;

    private void Update()
    {
        if (Time.time - lastAttackTime >= 1.0f) {
            lastAttackTime = Time.time;

            if (EnemyManager.Instance.CurrentEnemy == null) return;

            Attack();
        }
    }

    public void SetData(PetData data)
    {
        this.data = data;

        attackPower = data.attackPower;
        timeBetweenAttacks = data.timeBetweenAttacks;
        petImage.sprite = data.sprite;
    }

    private void Attack()
    {
        anim.Stop();
        anim.Play();

        EnemyManager.Instance.CurrentEnemy.Damage(attackPower);
    }
}
