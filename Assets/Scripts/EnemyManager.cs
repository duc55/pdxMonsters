using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [field: SerializeField] public Enemy CurrentEnemy { get; private set; }

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private EnemyData[] enemies;

    [Header("Components")]
    [SerializeField] private Transform canvas;

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

    public void CreateNewEnemy()
    {
        EnemyData enemyData = enemies[Random.Range(0, enemies.Length)];
        Enemy enemy = Instantiate(enemyPrefab, canvas);
        enemy.SetData(enemyData);
        CurrentEnemy = enemy;
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);

        CreateNewEnemy();

        GameManager.Instance.BackgroundCheck();
    }
}
