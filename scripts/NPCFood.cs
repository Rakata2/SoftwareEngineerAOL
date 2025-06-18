using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum FoodType
{
    None,
    Soup,
    Porridge,
    Sandwich
}
public class NPCFood : MonoBehaviour
{
    public DialogueScript dialogue;
    private bool TriggerDialogue = false;
    public GameObject TrayTablePanel;
    public FoodType RequestFood = FoodType.None;
    public NPCMovement MovingNPC;
    public string[] CurrentWrongFoodSelection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleFoodSelection(FoodType SelectedFood)
    {
        Debug.Log("Requested: " + MovingNPC.RequestedFood + " " + "selected: " + SelectedFood);
        // if (SelectedFood == MovingNPC.RequestedFood)
        // {
        //     // dialogue.Lines = dialogue.TestEnd;
        //     TrayTablePanel.SetActive(false);
        //     dialogue.HandleThankYouAndMove();

        // }
        // else
        // {

        //     Debug.Log("Wrong food selected");
        // }
        if (dialogue != null)
        {
            dialogue.HandleFoodChoice(SelectedFood.ToString());
        }
        else
        {
            Debug.LogWarning("Dialogue reference is missing in NPCFood");
        }
    }

    public void OnSoupClicked()
    {
        HandleFoodSelection(FoodType.Soup);
    }

    public void OnPorrdigeClick()
    {
        HandleFoodSelection(FoodType.Porridge);
    }

    public void OnSandwichClicked()
    {
        HandleFoodSelection(FoodType.Sandwich);
    }
}
