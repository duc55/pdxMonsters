using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "PetData", menuName = "Idle Clicker/Create New Pet")]
public class PetData : ScriptableObject
{
    public string petName;
    public string description;
    public int attackPower;
    public float timeBetweenAttacks;
    public float statScaleFactor = 1.0f;
    public Sprite sprite;
    public Sprite icon;

    public int GetAttackPower(int level) 
    {
        return Mathf.RoundToInt(attackPower + attackPower * level * statScaleFactor);
    }

    public float GetTimeBetweenAttacks(int level) 
    {
        const float reductionPerLevel = 0.15f;
        const float minAttackDelay = 0.01f;
        return Mathf.Max(timeBetweenAttacks - timeBetweenAttacks * level * statScaleFactor * reductionPerLevel, minAttackDelay);
    }
}
