using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    public TMP_Text TextBoxComponent;
    public string[] ShelterLines1 = { "Are there any beds available left?" };
    public string[] ShelterLines2 = { "Can I stay here for the night?" };
    public string[] ShelterLines3 = { "Is there any spot that has not been taken yet?" };
    public string[] ShelterLines4 = { "Can I get a bed to sleep on here?" };
    public string[] ShelterLines5 = { "May I rest here for the night?" };

    public string[] SoupLines1 = { "Do you have any soup left?" };
    public string[] SoupLines2 = { "I could eat something hot right now..." };
    public string[] SoupLines3 = { "May I have some soup?" };
    public string[] SoupLines4 = { "Any comfort food? kinda feeling under the weather." };
    public string[] SoupLines5 = { "I'll take the soup if you have any left." };

    public string[] PorridgeLines1 = { "Is there any porridge left?" };
    public string[] PorridgeLines2 = { "Do you have anything that is easy to digest?" };
    public string[] PorridgeLines3 = { "You have porridges right? i'll take one." };
    public string[] PorridgeLines4 = { "A porridge sounds nice to eat right now." };
    public string[] PorridgeLines5 = { "I'll take a bowl of porridge please." };

    public string[] SandwichLines1 = { "Can I get a sandwich please?" };
    public string[] SandwichLines2 = { "Are there any sandwiches left?" };
    public string[] SandwichLines3 = { "I'll take a sandwich." };
    public string[] SandwichLines4 = { "Bread good, have any?" };
    public string[] SandwichLines5 = { "That sandwich looks nice." };

    [HideInInspector]
    public string[] Lines;
    public float TextSpeed;
    private int index;
    private Coroutine TypingCoroutine;
    public GameObject ChoicePanel;
    public Button AllowButton, RejectButton;
    public bool ReadyForShelterchoice = false;

    // Start is called before the first frame update
    void Start()
    {
        TextBoxComponent.text = string.Empty;
        gameObject.SetActive(false);

        AllowButton.onClick.AddListener(HandleAllowShelter);
        RejectButton.onClick.AddListener(HandleRejectShelter);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextBoxComponent.text == Lines[index])
            {
                NextLine();
            }
            else
            {
                if (TypingCoroutine != null)
                {
                    StopCoroutine(TypingCoroutine);
                }
                TextBoxComponent.text = Lines[index];
            }
        }
    }
    public void StartDialogue()
    {
        index = 0;
        gameObject.SetActive(true);
        TypingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        TextBoxComponent.text = "";
        foreach (char c in Lines[index].ToCharArray())
        {
            TextBoxComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
    public void NextLine()
    {
        if (index < Lines.Length - 1)
        {
            index++;
            TextBoxComponent.text = "";
            if (TypingCoroutine != null)
            {
                StopCoroutine(TypingCoroutine);
            }
            TypingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            if (Lines == ShelterLines1 || Lines == ShelterLines2 || Lines == ShelterLines3 || Lines == ShelterLines4 || Lines == ShelterLines5)
            {
                ReadyForShelterchoice = true;
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ShowShelterChoices()
    {
        ChoicePanel.SetActive(true);
    }

    void HandleAllowShelter()
    {
        Debug.Log("Shelter Granted.");
        ChoicePanel.SetActive(false);
        gameObject.SetActive(false);
        ReadyForShelterchoice = false;
    }

    void HandleRejectShelter()
    {
        Debug.Log("Redirect to another shelter.");
        ChoicePanel.SetActive(false);
        gameObject.SetActive(false);
        ReadyForShelterchoice = false;
    }
}
