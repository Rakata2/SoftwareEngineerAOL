using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 0, 0);
    public float speed = 3f;
    public DialogueScript dialogue;
    private bool TriggerDialogue = false;
    public FoodType RequestedFood = FoodType.None;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (!TriggerDialogue && Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            TriggerDialogue = true;
            int choice = Random.Range(0, 20);
            // int choice = 8;
            if (choice == 0) {dialogue.Lines = dialogue.ShelterLines1; RequestedFood = FoodType.None; }
            else if (choice == 1){dialogue.Lines = dialogue.ShelterLines2; RequestedFood = FoodType.None;}
            else if (choice == 2){dialogue.Lines = dialogue.ShelterLines3;RequestedFood = FoodType.None;}
            else if (choice == 3){dialogue.Lines = dialogue.ShelterLines4;RequestedFood = FoodType.None;}
            else if (choice == 4){dialogue.Lines = dialogue.ShelterLines5;RequestedFood = FoodType.None;}

            else if (choice == 5){dialogue.Lines = dialogue.SoupLines1; dialogue.CurrentWrongFoodLines = dialogue.WrongSoup1; RequestedFood = FoodType.Soup;}
            else if (choice == 6){dialogue.Lines = dialogue.SoupLines2; dialogue.CurrentWrongFoodLines = dialogue.WrongSoup2; RequestedFood = FoodType.Soup;}
            else if (choice == 7){dialogue.Lines = dialogue.SoupLines3; dialogue.CurrentWrongFoodLines = dialogue.WrongSoup3; RequestedFood = FoodType.Soup;}
            else if (choice == 8){dialogue.Lines = dialogue.SoupLines4; dialogue.CurrentWrongFoodLines = dialogue.WrongSoup4; RequestedFood = FoodType.Soup;}
            else if (choice == 9){dialogue.Lines = dialogue.SoupLines5; dialogue.CurrentWrongFoodLines = dialogue.WrongSoup5; RequestedFood = FoodType.Soup;}

            else if (choice == 10){dialogue.Lines = dialogue.PorridgeLines1; dialogue.CurrentWrongFoodLines = dialogue.WrongPorridge1; RequestedFood = FoodType.Porridge;}
            else if (choice == 11){dialogue.Lines = dialogue.PorridgeLines2; dialogue.CurrentWrongFoodLines = dialogue.WrongPorridge2; RequestedFood = FoodType.Porridge;}
            else if (choice == 12){dialogue.Lines = dialogue.PorridgeLines3; dialogue.CurrentWrongFoodLines = dialogue.WrongPorridge3; RequestedFood = FoodType.Porridge;}
            else if (choice == 13){dialogue.Lines = dialogue.PorridgeLines4; dialogue.CurrentWrongFoodLines = dialogue.WrongPorridge4; RequestedFood = FoodType.Porridge;}
            else if (choice == 14){dialogue.Lines = dialogue.PorridgeLines5; dialogue.CurrentWrongFoodLines = dialogue.WrongPorridge5; RequestedFood = FoodType.Porridge;}

            else if (choice == 15){dialogue.Lines = dialogue.SandwichLines1; dialogue.CurrentWrongFoodLines = dialogue.WrongSandwich1; RequestedFood = FoodType.Sandwich;}
            else if (choice == 16){dialogue.Lines = dialogue.SandwichLines2; dialogue.CurrentWrongFoodLines = dialogue.WrongSandwich2; RequestedFood = FoodType.Sandwich;}
            else if (choice == 17){dialogue.Lines = dialogue.SandwichLines3; dialogue.CurrentWrongFoodLines = dialogue.WrongSandwich3; RequestedFood = FoodType.Sandwich;}
            else if (choice == 18){dialogue.Lines = dialogue.SandwichLines4; dialogue.CurrentWrongFoodLines = dialogue.WrongSandwich4; RequestedFood = FoodType.Sandwich;}
            else if (choice == 19){dialogue.Lines = dialogue.SandwichLines5; dialogue.CurrentWrongFoodLines = dialogue.WrongSandwich5; RequestedFood = FoodType.Sandwich;}
            dialogue.MovementNPC = this;
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }
    public void MoveToTheRight()
    {
        targetPosition = new Vector3(8f, transform.position.y, transform.position.z);
        TriggerDialogue = true;
    }
}
