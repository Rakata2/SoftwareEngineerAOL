using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;


public class DialogueScript : MonoBehaviour
{
    public TMP_Text TextBoxComponent; 
    public string[] ShelterLines = {"Excuse me... Can I please have shelter for the night?"};
    public string[] FoodLines = {"I'm starving... Can I please have some food?"};

    [HideInInspector]
    public string[] Lines;
    public float TextSpeed;
    private int index;
    private Coroutine TypingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        TextBoxComponent.text = string.Empty;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(TextBoxComponent.text == Lines[index])
            {
                NextLine();
            }
            else
            {
                if(TypingCoroutine != null)
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
        foreach(char c in Lines[index].ToCharArray())
        {
            TextBoxComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
    public void NextLine()
    {
        if(index<Lines.Length - 1)
        {
            index++;
            TextBoxComponent.text = "";
            if(TypingCoroutine != null)
            {
                StopCoroutine(TypingCoroutine);
            }
            TypingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
