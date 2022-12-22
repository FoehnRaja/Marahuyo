using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject turretShopPanel;
    private Node _currentNodeSelected;

    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }
    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if (_currentNodeSelected.isEmpty())
        {
            turretShopPanel.SetActive(true);
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
