using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0,0,0);
    public float speed = 3f;
    public DialogueScript dialogue;
    private bool TriggerDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        if(!TriggerDialogue && Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            TriggerDialogue = true;
            int choice = Random.Range(0, 2);
            if(choice == 0)
            {
                dialogue.Lines = dialogue.ShelterLines;
            }
            else
            {
                dialogue.Lines = dialogue.FoodLines;
            }
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }
}
