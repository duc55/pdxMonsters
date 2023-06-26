using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class PetInfoManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static PetInfoManager Instance;

    [Header("Components")]
    [SerializeField] private GameObject infoContainer;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI upgradePowerButtonText;
    [SerializeField] private TextMeshProUGUI upgradeSpeedButtonText;

    private Pet currentPet;
    private bool isMouseHovering = false;

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogWarning($"There can only be one PetInfoManager in the scene.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        HidePanel();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!isMouseHovering) {
                currentPet = null;
                HidePanel();
            }
        }
    }

    public void ShowPetInfo(Pet pet)
    {
        currentPet = pet;
        UpdatePanelInfo();
        ShowPanel();
    }

    public void TryPowerUp()
    {
        if (currentPet == null) return;

        int cost = currentPet.GetPowerUpCost();

        if (cost <= GameManager.Instance.Gold) {
            currentPet.LevelUpPower();
            GameManager.Instance.TakeGold(cost);

            UpdatePanelInfo();
        }
    }

    public void TrySpeedUp()
    {
        if (currentPet == null) return;

        int cost = currentPet.GetSpeedUpCost();

        if (cost <= GameManager.Instance.Gold) {
            currentPet.LevelUpSpeed();
            GameManager.Instance.TakeGold(cost);

            UpdatePanelInfo();
        }
    }

    private void ShowPanel()
    {
        infoContainer.SetActive(true);
    }
    
    private void HidePanel()
    {
        infoContainer.SetActive(false);
    }

    private void UpdatePanelInfo()
    {
        nameText.text = currentPet.GetPetName();
        powerText.text = "Power: " + currentPet.GetAttackPower();
        speedText.text = String.Format("Speed: {0:0.00}", 1f / currentPet.GetTimeBetweenAttacks());

        upgradePowerButtonText.text = "Power Up<br>(" + currentPet.GetPowerUpCost() + " Gold)";
        upgradeSpeedButtonText.text = "Speed Up<br>(" + currentPet.GetSpeedUpCost() + " Gold)";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseHovering = false;
    }
}
