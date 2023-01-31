using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject turretShopPanel;
    [SerializeField] private GameObject nodeUIPanel;

    [SerializeField] private TextMeshProUGUI upgradeText; 
    [SerializeField] private TextMeshProUGUI sellText; 
    [SerializeField] private TextMeshProUGUI turretlevelText; 
    [SerializeField] private TextMeshProUGUI totalCoinsText; 
    [SerializeField] private TextMeshProUGUI lifesText; 
    [SerializeField] private TextMeshProUGUI currentWaveText; 
    private Node _currentNodeSelected;

    private void Update()
    {
        totalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
        lifesText.text = LevelManager.Instance.TotalLives.ToString();
        currentWaveText.text = $"Wave{LevelManager.Instance.CurrentWave}";
    }

    public void CloseNodeUIPanel()
    {
        _currentNodeSelected.closeAttackRangeSprite();
        nodeUIPanel.SetActive(false);
    }

    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }

    public void UpgradeTurret()
    {
        _currentNodeSelected.Turret.TurretUpgrade.UpgradeTurret();
        UpdateUpgradeText();
        UpdateTurretLevel();
        UpdateSellValue();
    }

    public void SellTurret()
    {
        _currentNodeSelected.SellTurret();
        _currentNodeSelected = null;
        nodeUIPanel.SetActive(false);
    }

    private void ShowNodeUI()
    {
        nodeUIPanel.SetActive(true);
        UpdateUpgradeText();
        UpdateUpgradeText();
        UpdateSellValue();
    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = _currentNodeSelected.Turret.TurretUpgrade.UpgradeCost.ToString();
    }
    private void UpdateTurretLevel()
    {
        turretlevelText.text = $"Level {_currentNodeSelected.Turret.TurretUpgrade.Level}";
    }
    private void UpdateSellValue()
    {
        int sellAmount = _currentNodeSelected.Turret.TurretUpgrade.GetSellValue();
        sellText.text = sellAmount.ToString();
    }

    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if (_currentNodeSelected.isEmpty())
        {
            turretShopPanel.SetActive(true);
        }
        else
        {
            ShowNodeUI();
        }
    }

    private void OnEnable()
    {
        Node.onNodeSelected += NodeSelected;
    }
    private void OnDisable()
    {
        Node.onNodeSelected -= NodeSelected;
    }
}
