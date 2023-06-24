using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [field: SerializeField] public Enemy CurrentEnemy { get; private set; }

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private EnemyData[] enemies;

    [Header("Components")]
    [SerializeField] private Transform canvas;

    public event Action<int> OnEnemyDefeated;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one EnemyManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        CreateNewEnemy();
    }

    private void DefeatEnemy(Enemy enemy)
    {
        enemy.OnDefeated -= Enemy_OnDefeated;
        Destroy(enemy.gameObject);
        CurrentEnemy = null;

        OnEnemyDefeated?.Invoke(enemy.GetGoldToGive());

        GameManager.Instance.BackgroundCheck();
    }

    private void Enemy_OnDefeated()
    {
        DefeatEnemy(CurrentEnemy);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float timeBeforeRespawning = 1.0f;
        yield return new WaitForSeconds(timeBeforeRespawning);
        CreateNewEnemy();
    }

    private void CreateNewEnemy()
    {
        EnemyData enemyData = enemies[Random.Range(0, enemies.Length)];
        Enemy enemy = Instantiate(enemyPrefab, canvas);
        enemy.SetData(enemyData);
        enemy.OnDefeated += Enemy_OnDefeated;
        CurrentEnemy = enemy;
    }
}
