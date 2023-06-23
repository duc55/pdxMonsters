using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [field: SerializeField] public Enemy CurrentEnemy { get; private set; }

    [SerializeField] private GameObject[] enemyPrefabs;

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

    public void CreateNewEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject obj = Instantiate(enemyToSpawn, canvas);

        CurrentEnemy = obj.GetComponent<Enemy>();
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);

        CreateNewEnemy();

        GameManager.Instance.BackgroundCheck();
    }
}
