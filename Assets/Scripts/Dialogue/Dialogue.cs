using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public GameObject[] dialogueText;
    public TextMeshProUGUI[] textComponent;

    public Sprite[] sprites;
    public Image characterSprite;

    public GameObject[] characterName;

    public int index = 0;

    public DialogueControl control;

    private string text;

    //Start the dialogue and type the first text already
    public void OnEnable()
    {
        //Activate first text
        DeactivateTexts();
        dialogueText[index].SetActive(true);
        
        characterSprite.sprite = sprites[index];
        characterName[index].SetActive(true);

        //Type the first text
        string text = textComponent[index].text;
        textComponent[index].text = "";
        StartCoroutine(TypeLine(text));
    }

    //Deactivate all texts to get to the next one correctly
    public void DeactivateTexts()
    {
        for (int i = 0; i < dialogueText.Length - 1; i++)
        {
            dialogueText[i].SetActive(false);
        }

        for (int i = 0;i < characterName.Length - 1;i++)
        {
            characterName[i].SetActive(false);
        }
    }

    //Function to call the next text
    public void NextText()
    {
        if (index < dialogueText.Length - 1)
        {
            index++;
            DeactivateTexts();


            characterSprite.sprite = sprites[index];
            characterName[index].SetActive(true);
            
            dialogueText[index].SetActive(true);
            string text = textComponent[index].text;
            textComponent[index].text = "";
            StartCoroutine(TypeLine(text));

        }
        else if (index == dialogueText.Length - 1)
        {
            control.EndDialogue();
            StopAllCoroutines();
        }
    }


    /// <summary>
    /// Types the text character by character using the text speed in the game manager. The text speed is in the game manager so it can be changed in the settings later.
    /// </summary>
    /// <param name="text"> this is a temporary one just so we can write the text up in the inspector and it will not be cut out </param>
    /// <returns></returns>
    IEnumerator TypeLine(string text)
    {
        GameManager manager = GameManager.Instance;

        foreach (char c in text.ToCharArray())
        {
            textComponent[index].text += c;
            yield return new WaitForSeconds(manager.textSpeed);
        }
    }
}


