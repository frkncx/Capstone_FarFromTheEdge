using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEditor.Rendering.LookDev;

public class DialogueController : MonoBehaviour
{
    [Header("Control Settings")]
    public string dialogueName = "";
    public bool isDialogueOver = false;


    [Header("Dialogue Settings")]
    public TextMeshProUGUI textComponent;
    public string[] dialogueText; //previous lines
    public float textSpeed;
    private int index;

    private void OnEnable() //The video references this as Start, not OnEnable
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    /// <summary>
    /// Skip Dialogue by pressing left click
    /// </summary>
    /// <param name="context"></param>
    public void SkipDialogue()
    {
        if (textComponent.text == dialogueText[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = dialogueText[index];
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueText[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogueText.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            isDialogueOver = true; //I added this line
            gameObject.SetActive(false);
            this.enabled = false; //I added this line
        }
    }
}
