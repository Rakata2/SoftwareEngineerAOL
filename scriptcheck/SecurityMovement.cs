using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SecurityMovement : MonoBehaviour
{
    public Vector3 targetPositionSecurity = new Vector3(-1, 0, 0);
    public float speed = 5f;
    public DialogueScript dialogue;
    private bool TriggerDialogue = false;
    public GameObject NPC;
    public GameObject THEBUTTON;
    ButtonSecurity TheButton;

    // Start is called before the first frame update
    void Start()
    {
        TheButton = THEBUTTON.GetComponent<ButtonSecurity>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositionSecurity, 2 * speed * Time.deltaTime);

    }

    public void ButtonPressed()
    {
        
        Debug.LogWarning("Done");
        
    }

    public void SecurityToRight()
    {
        targetPositionSecurity = new Vector3(8f, transform.position.y, transform.position.z);
        Invoke("SecurityCameBack", 3f);
    }

    public void SecurityCameBack()
    {
        targetPositionSecurity = new Vector3(0, 0, 0);
        Invoke("SecurityTalk", 1.5f);
    }
    
    public void SecurityTalk()
    {
        int choiceSecurity = Random.Range(0,2);
        if (choiceSecurity == 0){dialogue.Lines = dialogue.Security1;}
        else if (choiceSecurity == 1){dialogue.Lines = dialogue.Security2;}
        else if (choiceSecurity == 2){dialogue.Lines = dialogue.Security3;}

        dialogue.gameObject.SetActive(true);
        dialogue.StartDialogue();
        TheButton.ResetButton();
        Invoke("SecurityLeave", 4f);
    }

    public void SecurityLeave()
    {
        dialogue.gameObject.SetActive(false);
        targetPositionSecurity = new Vector3(8f, transform.position.y, transform.position.z);
    }

}
