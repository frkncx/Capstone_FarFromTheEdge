using UnityEngine;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
    public GameObject[] dialogueText;
    public int index = 0;

    public DialogueControl control;


    public void OnEnable()
    {
        DeactivateTexts();
        dialogueText[index].SetActive(true);
    }

    public void DeactivateTexts()
    {
        for (int i = 0; i < dialogueText.Length - 1; i++)
        {
            dialogueText[i].SetActive(false);
        }
    }

    public void NextText()
    {
        if (index < dialogueText.Length - 1)
        {
            index++;
            DeactivateTexts();
            dialogueText[index].SetActive(true);
        }
        else if (index == dialogueText.Length - 1)
        {
            control.EndDialogue();
        }
    }
}

