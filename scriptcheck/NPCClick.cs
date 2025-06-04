using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCClick : MonoBehaviour
{
    public DialogueScript DialogueStuff;
    public Button CloseButton;
    public UIPoppupManager PopupManager;

    void Start()
    {
        if (CloseButton != null)
        {
            CloseButton.onClick.AddListener(CloseUI);
        }
    }
    void OnMouseDown()
    {
        if (DialogueStuff != null && DialogueStuff.ReadyForShelterchoice)
        {
            if (PopupManager != null && DialogueStuff.ChoicePanel != null)
            {
                PopupManager.ShowPopup(DialogueStuff.ChoicePanel);
                DialogueStuff.ReadyForShelterchoice = false;
            }
        }
    }

    void CloseUI()
    {
        if (DialogueStuff.ChoicePanel != null)
        {
            DialogueStuff.ChoicePanel.SetActive(false);
        }
    }
}
