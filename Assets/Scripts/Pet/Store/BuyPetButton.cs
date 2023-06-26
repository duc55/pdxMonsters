using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPetButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image petIcon;
    [SerializeField] private Button buyButton;

    private PetData data;

    public event Action OnPetBought;

    private void Awake()
    {
        Reset();
    }

    public void SetPet(PetData data)
    {
        buyButton.interactable = true;

        this.data = data;

        petIcon.sprite = data.icon;
    }

    public void BuyPet()
    {
        if (data == null) return;

        PetManager.Instance.SpawnPet(data);
        OnPetBought?.Invoke();
    }

    public void Reset()
    {
        buyButton.interactable = false;
        data = null;
    }
}
