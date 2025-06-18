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
    public string[] WrongSoup1 = { "I said soup, not that" };
    public string[] SoupLines2 = { "I could eat something hot right now..." };
    public string[] WrongSoup2 = { "I mean.. something hot, like a soup" };
    public string[] SoupLines3 = { "May I have some soup?" };
    public string[] WrongSoup3 = { "I said soup" };
    public string[] SoupLines4 = { "Any comfort food? kinda feeling under the weather." };
    public string[] WrongSoup4 = { "I meant like something warm and liquidy" };
    public string[] SoupLines5 = { "I'll take the soup if you have any left." };
    public string[] WrongSoup5 = { "Excuse me, i said soup" };
    public string[] PorridgeLines1 = { "Is there any porridge left?" };
    public string[] WrongPorridge1 = { "I said porridge" };
    public string[] PorridgeLines2 = { "Do you have anything that is easy to digest?" };
    public string[] WrongPorridge2 = { "I meant something that is slightly thick but easy to digest" };
    public string[] PorridgeLines3 = { "You have porridges right? i'll take one." };
    public string[] WrongPorridge3 = { "Excuse me i said porridges" };
    public string[] PorridgeLines4 = { "A porridge sounds nice to eat right now." };
    public string[] WrongPorridge4 = { "I want porridges, not that" };
    public string[] PorridgeLines5 = { "I'll take a bowl of porridge please." };
    public string[] WrongPorridge5 = { "Porridges please, not this" };
    public string[] SandwichLines1 = { "Can I get a sandwich please?" };
    public string[] WrongSandwich1 = { "I said sandwich" };
    public string[] SandwichLines2 = { "Are there any sandwiches left?" };
    public string[] WrongSandwich2 = { "Excuse me, i said sandwich" };
    public string[] SandwichLines3 = { "I'll take a sandwich." };
    public string[] WrongSandwich3 = { "Sandwich, not this" };
    public string[] SandwichLines4 = { "Bread good, have any?" };
    public string[] WrongSandwich4 = { "Me said bread, not this" };
    public string[] SandwichLines5 = { "That sandwich looks nice." };
    public string[] WrongSandwich5 = { "I'd prefer a sandwich please instead of this" };

    public string[] TestEnd = { "Thanks" };
    public string[] ThankYouLines = { "Thank you so much.." };
    public string[] ShelterSecondChance = { "Please... I don't have anywhere to live" };
    public string[] ShelterFullyReject = { "you're mean ..." };
    public string[] FullyWrongFood = { "Why don't you understand me..." };

    public string[] Security1 = {"We have taken care of the trouble have a good day"};
    public string[] Security2 = {"Hope we didn't take too long have a nice day"};
    public string[] Security3 = {"Are you alright? we'll take it from here"};

    public string[] BadGuy1 = {"Hey, mind giving me all the food you got?"};
    public string[] BadGuy2 = {"Mind if i smoke here?"};
    public string[] BadGuy3 = {"Those foods are all free right? i'll take them all"};
    public string[] BadGuy4 = {"hEi CaN i GET a DRInk?"};
    public string[] BadGuyDeny4 = {"WhT do yOU MEAN no? I Wan A drink Damnit!!"};
    public string[] BadGuy5 = {"hey hey HEY give me some money cmon now cmon"};
    public string[] BadGuyDeny5 = {"hey who said you get to choose? now hand over your wallet"};

    [HideInInspector]
    public string[] Lines;
    public float TextSpeed;
    private int index;
    private Coroutine TypingCoroutine;
    public GameObject ChoicePanel;
    public GameObject TrayTablePanel;
    public Button AllowButton, RejectButton;
    public bool ReadyForShelterchoice = false;
    private bool IsThankYouDialogue = false;
    private bool IsMeanDialogue = false;
    private bool IsWrongFoodDialogue = false;
    int RejectionCount = 0;
    public int WrongFoodCount = 0;
    [HideInInspector] public string[] CurrentWrongFoodLines;

    [HideInInspector] public NPCMovement MovementNPC;

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
        if (IsThankYouDialogue) return;
        if (IsMeanDialogue) return;
        if (IsWrongFoodDialogue) return;
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
        ReadyForShelterchoice = false;
        HandleThankYouAndMove();
    }

    void HandleRejectShelter()
    {
        Debug.Log("NPC will ask again");
        ChoicePanel.SetActive(false);
        ReadyForShelterchoice = false;
        HandleAllRejections();
    }

    public void HandleThankYouAndMove()
    {
        Lines = ThankYouLines;
        index = 0;
        IsThankYouDialogue = true;
        gameObject.SetActive(true);
        TypingCoroutine = StartCoroutine(TypeLine());
        StartCoroutine(MoveNPCAfterDelay());
    }

    public void HandleAllRejections()
    {
        RejectionCount++;
        if (RejectionCount < 2)
        {
            gameObject.SetActive(true);
            ChoicePanel.SetActive(false);
            ReadyForShelterchoice = false;
            StartCoroutine(AskForAnotherChance());
        }
        else
        {
            Debug.Log("NPC will leave");
            Lines = ShelterFullyReject;
            index = 0;
            IsMeanDialogue = true;
            gameObject.SetActive(true);
            TypingCoroutine = StartCoroutine(TypeLine());
            StartCoroutine(SayMeanAndMove());
        }
    }

    IEnumerator MoveNPCAfterDelay()
    {
        yield return new WaitUntil(() => TextBoxComponent.text == Lines[index]);
        yield return new WaitForSeconds(1f);
        if (MovementNPC != null)
        {
            MovementNPC.MoveToTheRight();
        }
        else
        {
            Debug.LogWarning("No npc reference movement set");
        }
        gameObject.SetActive(false);
        IsThankYouDialogue = false;
    }

    IEnumerator AskForAnotherChance()
    {
        index = 0;
        Lines = ShelterSecondChance;
        TextBoxComponent.text = "";
        gameObject.SetActive(true);

        if (TypingCoroutine != null)
        {
            StopCoroutine(TypingCoroutine);
        }
        TypingCoroutine = StartCoroutine(TypeLine());
        ReadyForShelterchoice = true;
        yield break;
    }

    IEnumerator SayMeanAndMove()
    {
        yield return new WaitUntil(() => TextBoxComponent.text == Lines[index]);
        yield return new WaitForSeconds(1f);
        if (MovementNPC != null)
        {
            MovementNPC.MoveToTheRight();
        }
        else
        {
            Debug.LogWarning("No npc reference movement set");
        }
        gameObject.SetActive(false);
        IsMeanDialogue = false;
    }


    public void HandleFoodChoice(string ChosenFood)
    {
        if (MovementNPC == null)
        {
            Debug.LogWarning("No NPC attached to this dialogue");
            return;
        }

        FoodType selected;
        if (!System.Enum.TryParse(ChosenFood, true, out selected))
        {
            Debug.LogWarning("Invalid food type: " + ChosenFood);
            return;
        }

        if (MovementNPC.RequestedFood == selected)
        {
            Debug.Log("Correct food given: " + ChosenFood);
            TrayTablePanel.SetActive(false);
            HandleThankYouAndMove();
        }
        else
        {
            Debug.Log("Incorrect " + MovementNPC.RequestedFood + "it was: " + ChosenFood);
            WrongFoodCount++;
            TrayTablePanel.SetActive(false);
            if (WrongFoodCount < 2)
            {
                Debug.Log("NPC will ask the second time");
                gameObject.SetActive(true);
                ChoicePanel.SetActive(false);
                StartCoroutine(AskForFoodSecondChance());
            }
            else
            {
                Debug.Log("Skill issue");
                Lines = FullyWrongFood;
                index = 0;
                IsWrongFoodDialogue = true;
                gameObject.SetActive(true);
                TypingCoroutine = StartCoroutine(TypeLine());
                StartCoroutine(FailedFoodInteractionAndMove());
            }
        }
    }

    IEnumerator AskForFoodSecondChance()
    {
        index = 0;
        Lines = CurrentWrongFoodLines;
        TextBoxComponent.text = "";
        gameObject.SetActive(true);

        if (TypingCoroutine != null)
        {
            StopCoroutine(TypingCoroutine);
        }
        TypingCoroutine = StartCoroutine(TypeLine());
        yield break;
    }

    IEnumerator FailedFoodInteractionAndMove()
    {
        yield return new WaitUntil(() => TextBoxComponent.text == Lines[index]);
        yield return new WaitForSeconds(1f);
        if (MovementNPC != null)
        {
            MovementNPC.MoveToTheRight();
        }
        else
        {
            Debug.LogWarning("No npc reference movement set");
        }
        gameObject.SetActive(false);
        IsWrongFoodDialogue = false;
    }
}
