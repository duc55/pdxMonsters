using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PetManager : MonoBehaviour
{
    public static PetManager Instance;

    [SerializeField] private int startingPetPrice;

    [SerializeField] private Pet petPrefab;
    [SerializeField] private PetData[] pets;

    [Header("Components")]
    [SerializeField] private Transform petContainerTransform;
    [SerializeField] private TextMeshProUGUI hireButtonText;

    private int currentPetPrice;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one PetManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdatePetPrice();
    }

    public void TryToBuyPet()
    {
        if (GameManager.Instance.Gold >= currentPetPrice) {
            GameManager.Instance.TakeGold(currentPetPrice);
            SpawnPet();
            UpdatePetPrice();
        }
    }

    private void SpawnPet()
    {
        PetData petData = pets[Random.Range(0, pets.Length)];
        Pet pet = Instantiate(petPrefab, petContainerTransform);
        pet.SetData(petData);
    }

    private void UpdatePetPrice()
    {
        int currentPetCount = petContainerTransform.childCount;
        currentPetPrice = startingPetPrice + currentPetCount * startingPetPrice;
        hireButtonText.text = "Hire Pet<br>(" + currentPetPrice.ToString() + " Gold)";
    }
}
