using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public static PetManager Instance;

    [SerializeField] private Pet petPrefab;
    [SerializeField] private PetData[] pets;

    [Header("Components")]
    [SerializeField] private Transform petContainerTransform;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one PetManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SpawnPet()
    {
        PetData petData = pets[Random.Range(0, pets.Length)];
        Pet pet = Instantiate(petPrefab, petContainerTransform);
        pet.SetData(petData);
    }
}
