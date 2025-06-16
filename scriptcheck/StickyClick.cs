using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickyClick : MonoBehaviour
{
    public GameObject StickyPanel;
    public Button CloseButton;
    public UIPoppupManager PopupManager;

    // Start is called before the first frame update
    void Start()
    {
        if (StickyPanel != null)
        {
            StickyPanel.SetActive(false);
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
        if (StickyPanel && PopupManager != null)
        {
            PopupManager.ShowPopup(StickyPanel);
        }
        else
        {
            PopupManager.ClosePopup(StickyPanel);
        }
    }

    void CloseUI()
    {
        if (StickyPanel && PopupManager != null)
        {
            PopupManager.ClosePopup(StickyPanel);
        }
    }
    
}
