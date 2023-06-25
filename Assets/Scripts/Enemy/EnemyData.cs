using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Idle Clicker/Create New Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHp;
    public int goldToGive;
    public float statScaleFactor = 0.5f;
    public Sprite sprite;

    public int GetMaxHp(int level)
    {
        return Mathf.RoundToInt(maxHp + maxHp * level * statScaleFactor);
    }

    public int GetGoldToGive(int level)
    {
        return Mathf.RoundToInt(goldToGive + goldToGive * level);
    }
}
