using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStoreManager : MonoBehaviour
{
    public static PetStoreManager Instance;

    [SerializeField] private BuyPetButton[] buyButtons;

    [Header("Components")]
    [SerializeField] private Transform containerTransform;

    public event Action OnStoreClosed;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one PetStoreManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        HideStore();
    }

    private void OnEnable()
    {
        foreach (BuyPetButton button in buyButtons) {
            button.OnPetBought += HideStore;
        }
    }

    private void OnDisable()
    {
        foreach (BuyPetButton button in buyButtons) {
            button.OnPetBought -= HideStore;
        }
    }

    public void ShowStore()
    {
        foreach (BuyPetButton button in buyButtons) {
            button.SetPet(PetManager.Instance.GetRandomPetData());
        }

        containerTransform.gameObject.SetActive(true);
    }

    public void HideStore()
    {
        foreach (BuyPetButton button in buyButtons) {
            button.Reset();
        }

        containerTransform.gameObject.SetActive(false);

        OnStoreClosed?.Invoke();
    }

    public bool IsStoreOpen()
    {
        return containerTransform.gameObject.activeSelf;
    }
}
