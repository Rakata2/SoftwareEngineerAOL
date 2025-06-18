using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSecurity : MonoBehaviour
{
    public GameObject ButtonSecurityIdle;
    public GameObject ButtonSecurityPressed;
    public GameObject Security;
    public GameObject NPC;
    NPCMovement moveNPC;
    SecurityMovement moveSecurity;
    // Start is called before the first frame update
    void Start()
    {
        moveSecurity = Security.GetComponent<SecurityMovement>();
        moveNPC = NPC.GetComponent<NPCMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        ButtonSecurityIdle.SetActive(false);
        ButtonSecurityPressed.SetActive(true);
        Security.SetActive(true);
        moveSecurity.SecurityToRight();
        moveNPC.GotChased();
    }

    public void ResetButton()
    {
        ButtonSecurityIdle.SetActive(true);
        ButtonSecurityPressed.SetActive(false);
    }
}
