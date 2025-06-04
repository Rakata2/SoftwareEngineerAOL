using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ListUIClick : MonoBehaviour
{
    public GameObject ListUIPanel;
    public Button CloseButton;
    public UIPoppupManager PopupManager;
    // Start is called before the first frame update
    void Start()
    {
        if (ListUIPanel != null)
        {
            ListUIPanel.SetActive(false);
        }


        if (CloseButton != null)
            CloseButton.onClick.AddListener(CloseUI);
    }

    void OnMouseDown()
    {
        ToggleUI();
    }

    void ToggleUI()
    {
        if (ListUIPanel && PopupManager != null)
        {
            PopupManager.ShowPopup(ListUIPanel);
        }
        else
        {
            PopupManager.ClosePopup(ListUIPanel);
        }
    }

    void CloseUI()
    {
        if (ListUIPanel && PopupManager != null)
        {
            PopupManager.ClosePopup(ListUIPanel);
        }
    }
}
