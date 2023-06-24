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
    public Sprite sprite;
}
