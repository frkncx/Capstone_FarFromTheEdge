using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public enum CharacterType { Crafter, Alchemist, Player }

public class DialogueControl : MonoBehaviour
{
    [Header("Dialogue Type")]
    public CharacterType characterType;
    
    [Header("Dialogue Settings")]
    public GameObject dialogueBox;
    public Quest quest;

    bool dialogueStarted = false;
    bool playerHit = false;
    bool canInteract = true;

    // For each player self-dialogue event
    public bool selfDialogueEventComplete = false;

    [Header("Collision Settings")]
    public float dialogueRange = 2f;
    public LayerMask playerLayer;
    private Vector3 position;

    [Header("Activate Object for This Dialogue")]
    public GameObject objectToActivate;

    private Dialogue dialogueComponent;

    void Awake()
    {
        dialogueComponent = dialogueBox.GetComponent<Dialogue>();
    }

    void Update()
    {
        if (characterType == CharacterType.Crafter)
        {
            // Stop interaction if quest is completed (ONLY FOR THE CRAFTER)
            if (quest.state == QuestState.Completed && !GameManager.Instance.Quest1ReadytoComplete)
                return;
        }
        else if (characterType == CharacterType.Alchemist)
        {
            //// Stop interaction if quest is completed (ONLY FOR THE ALCHEMIST)
            //if (quest.state == QuestState.Completed && !GameManager.Instance.Quest2ReadytoComplete)
            //    return;
        }


        ShowDialogue();

        if (characterType == CharacterType.Crafter && playerHit && !dialogueStarted && canInteract && Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameManager.Instance.IsPlayedPaused = true;

            // check quest state for completion here
            if (quest.state == QuestState.InProgress && GameManager.Instance.Quest1ReadytoComplete)
            {
                quest.state = QuestState.Completed; // show the completion dialogue
                GameManager.Instance.Quest1ReadytoComplete = false;
            }

            dialogueBox.SetActive(true);
            dialogueStarted = true;
            canInteract = false;

            // Start the dialogue
            dialogueComponent.StartQuestDialogue(quest);

            var playerInput = GetComponent<PlayerInput>();
            if (playerInput != null)
                playerInput.DeactivateInput();
        }
        else if (characterType == CharacterType.Player && playerHit && !dialogueStarted && !selfDialogueEventComplete)
        {
            GameManager.Instance.IsPlayedPaused = true;

            dialogueBox.SetActive(true);
            dialogueStarted = true;

            if (!selfDialogueEventComplete && objectToActivate != null)
                objectToActivate.SetActive(true);

            // Start the dialogue
            dialogueComponent.StartPlayerDialogue();

            var playerInput = GetComponent<PlayerInput>();
            if (playerInput != null)
                playerInput.DeactivateInput();
        }

        // PLAYER SELF-DIALOGUE ADVANCING
        if (dialogueStarted && characterType == CharacterType.Player)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                GameManager.Instance.IsPlayedPaused = true;
                dialogueComponent.NextText();
            }
        }

        // Wait for E to be released before reenabling interaction
        if (!Keyboard.current.eKey.isPressed && dialogueStarted == false)
        {
            canInteract = true;
        }
    }

    void ShowDialogue()
    {
        position = transform.position;
        Collider[] hit = Physics.OverlapSphere(position, dialogueRange, playerLayer);
        playerHit = hit.Length > 0;
    }

    public void EndDialogue()
    {
        GameManager.Instance.IsPlayedPaused = false;
        dialogueBox.SetActive(false);

        var playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
            playerInput.ActivateInput();

        // Update quest progress
        if (characterType != CharacterType.Player)
        {
            if (quest.state == QuestState.NotStarted && dialogueStarted)
            {
                quest.state = QuestState.InProgress;
            }
            else if (quest.state == QuestState.InProgress && GameManager.Instance.CheckArea3Quest())
            {
                GameManager.Instance.Quest1ReadytoComplete = true;
            }
            // If currently showing the completion dialogue, then mark complete
            else if (quest.state == QuestState.Completed && dialogueStarted)
            {
                // Quest fully done, give rewards
                GameManager.Instance.Item3Count = 0;
                GameManager.Instance.MagicItem += 1;
            }
        }
        else
        {
            selfDialogueEventComplete = true;
        }

            dialogueStarted = false;
    }
}
