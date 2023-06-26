using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Button hireButton;

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

    private void OnEnable()
    {
        PetStoreManager.Instance.OnStoreClosed += PetStoreManager_OnStoreClosed;
    }

    private void OnDisable()
    {
        PetStoreManager.Instance.OnStoreClosed -= PetStoreManager_OnStoreClosed;
    }

    public void TryToOpenStore()
    {
        if (GameManager.Instance.Gold >= currentPetPrice) {
            GameManager.Instance.TakeGold(currentPetPrice);

            PetStoreManager.Instance.ShowStore();

            UpdatePetPrice();
            hireButton.interactable = false;
        }
    }

    public void SpawnPet(PetData petData)
    {
        Pet pet = Instantiate(petPrefab, petContainerTransform);
        pet.SetData(petData);
    }

    public PetData GetRandomPetData()
    {
        return pets[Random.Range(0, pets.Length)];
    }

    private void UpdatePetPrice()
    {
        int currentPetCount = petContainerTransform.childCount;
        
        //Increase count if player is about to hire pet
        if (PetStoreManager.Instance.IsStoreOpen()) {
            currentPetCount++;
        }
        
        currentPetPrice = startingPetPrice + currentPetCount * startingPetPrice;
        hireButtonText.text = "<b>Hire Pet</b><br>(" + currentPetPrice.ToString() + " Gold)";
    }

    private void PetStoreManager_OnStoreClosed()
    {
        hireButton.interactable = true;
    }
}
