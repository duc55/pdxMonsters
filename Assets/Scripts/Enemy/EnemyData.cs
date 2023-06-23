using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Create New Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int goldToGive;
    public Sprite sprite;
}
