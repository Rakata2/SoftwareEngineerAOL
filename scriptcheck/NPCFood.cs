using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class NPCFood : MonoBehaviour
{
    public DialogueScript dialogue;
    private bool TriggerDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sandwichthanks()
    {
        if(!TriggerDialogue)
        {
            TriggerDialogue = true;
            dialogue.Lines = dialogue.TestEnd;
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }

    public void Porridgethanks()
    {
        if(!TriggerDialogue)
        {
            TriggerDialogue = true;
            dialogue.Lines = dialogue.TestEnd;
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }

    public void Soupthanks()
    {
        if(!TriggerDialogue)
        {
            TriggerDialogue = true;
            dialogue.Lines = dialogue.TestEnd;
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
        }
    }
}
