using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Idle Clicker/Create New Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int goldToGive;
    public Sprite sprite;
}
