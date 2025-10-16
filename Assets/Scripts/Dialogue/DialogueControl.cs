using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DialogueControl : MonoBehaviour
{
    public GameObject dialogueBox;
    bool dialogueStarted = false;
    bool dialogueFinished = false;


    [Header("Collision settings")] //This I got from my other dialogue videos
    public float dialogueRange;
    public LayerMask playerLayer;
    private Vector3 position;
    bool playerHit = false;

    void Update()
    {
        if (!dialogueFinished)
        {
            ShowDialogue(); //Check if player can start the interaction because it is near

            if (Keyboard.current.eKey.wasPressedThisFrame && playerHit && !dialogueStarted)
            {
                dialogueBox.SetActive(true);
                dialogueStarted = false;
            }
        }
    }
    void ShowDialogue() //A collider check without having a collider
    {
        position = transform.position;

        Collider[] hit = Physics.OverlapSphere(position, dialogueRange, playerLayer);

        if (hit.Length != 0)
        {
            playerHit = true;
            Debug.Log("Player can dialogue");
            Debug.Log(hit);

            //Make it popup the E to talk
        }
        else
        {
            playerHit = false;
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueFinished = true;
    }
}
