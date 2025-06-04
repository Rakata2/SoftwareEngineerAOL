using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayTableClick : MonoBehaviour
{
    public GameObject TrayTablePanel;
    public Button CloseButton;
    public UIPoppupManager PopupManager;

    // Start is called before the first frame update
    void Start()
    {
        if (TrayTablePanel != null)
        {
            TrayTablePanel.SetActive(false);
        }
            

        if(CloseButton != null)
            CloseButton.onClick.AddListener(CloseUI);
    }

    void OnMouseDown()
    {
        ToggleUI();
    }

    void ToggleUI()
    {
        if (TrayTablePanel && PopupManager != null)
        {
            PopupManager.ShowPopup(TrayTablePanel);
        }
        else
        {
            PopupManager.ClosePopup(TrayTablePanel);
        }
    }

    void CloseUI()
    {
        if (TrayTablePanel && PopupManager != null)
        {
            PopupManager.ClosePopup(TrayTablePanel);
        }
    }
    // Update is called once per frame
}
