using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] public Enemy currentEnemy;

    [SerializeField] private Transform canvas;

    public static EnemyManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void CreateNewEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject obj = Instantiate(enemyToSpawn, canvas);

        currentEnemy = obj.GetComponent<Enemy>();
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);

        CreateNewEnemy();

        GameManager.Instance.BackgroundCheck();
    }
}
