using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TurretCard : MonoBehaviour
{
    public static Action<TurretSettings> OnPlaceTurret;

    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;
    [SerializeField] private int turretTotalCost;

    public TurretSettings TurretLoaded { get; set; }
    public void SetupTurretButton(TurretSettings turretSettings)
    {
        TurretLoaded = turretSettings;
        turretImage.sprite = turretSettings.TurretshopSprite;
        turretCost.text = turretSettings.TurretShopCost.ToString();
        turretTotalCost = TurretLoaded.TurretShopCost;
    }

    public void PlaceTurret()
    {
        if (CurrencySystem.Instance.TotalCoins >= TurretLoaded.TurretShopCost)
        {
            CurrencySystem.Instance.RemoveCoins(TurretLoaded.TurretShopCost);
            UIManager.Instance.CloseTurretShopPanel();
            OnPlaceTurret?.Invoke(TurretLoaded);
        }
    }
}
