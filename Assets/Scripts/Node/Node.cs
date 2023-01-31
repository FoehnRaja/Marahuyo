using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    public static Action<Node> onNodeSelected;
    public static Action OnTurretSold;

    [SerializeField] private GameObject attackRangeSprite;
   public Turret Turret { get; set; }

    private float _rangeSize;
    private Vector3 _rangeOriginalSize;

    private void Start()
    {
        _rangeSize = attackRangeSprite.GetComponent<SpriteRenderer>().bounds.size.y;
        _rangeOriginalSize = attackRangeSprite.transform.localScale;
    }

    public void SetTurret(Turret turret)
    {
        Turret = turret;
        turret.transform.localPosition = new Vector3(0f, 0.47f,0f);
    }

    public bool isEmpty()
    {
        return Turret == null;
    }

    public void closeAttackRangeSprite()
    {
        attackRangeSprite.SetActive(false);
    }
    public void SelectTurret()
    {
        onNodeSelected?.Invoke(this);
        if (!isEmpty())
        {
            ShowTurretInfo();
        }
    }

    public void SellTurret()
    {
        if (!isEmpty())
        {
            CurrencySystem.Instance.AddCoins(Turret.TurretUpgrade.GetSellValue());
            Destroy(Turret.gameObject);
            Turret = null;
            attackRangeSprite.SetActive(false);
            OnTurretSold?.Invoke();
        }
    }
    private void ShowTurretInfo()
    {
        attackRangeSprite.SetActive(true);
        attackRangeSprite.transform.localScale = _rangeOriginalSize * Turret.AttackRange / (_rangeSize / 2);
    }
}
