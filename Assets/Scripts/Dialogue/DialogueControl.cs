using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DialogueControl : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public GameObject dialogueBox;
    public Quest quest;

    bool dialogueStarted = false;
    bool playerHit = false;
    bool canInteract = true;

    [Header("Collision Settings")]
    public float dialogueRange = 2f;
    public LayerMask playerLayer;
    private Vector3 position;

    private Dialogue dialogueComponent;

    void Awake()
    {
        dialogueComponent = dialogueBox.GetComponent<Dialogue>();
    }

    void Update()
    {
        // Stop interaction if quest is completed
        if (quest.state == QuestState.Completed && !GameManager.Instance.Quest1ReadytoComplete)
            return;

        ShowDialogue();

        if (playerHit && !dialogueStarted && canInteract && Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameManager.Instance.IsPlayedPaused = true;

            // check quest state for completion here
            if (quest.state == QuestState.InProgress && GameManager.Instance.Quest1ReadytoComplete)
            {
                quest.state = QuestState.Completed; // now show the "completion" dialogue
                GameManager.Instance.Quest1ReadytoComplete = false;
            }

            dialogueBox.SetActive(true);
            dialogueStarted = true;
            canInteract = false;

            // Start the dialogue
            dialogueComponent.StartQuestDialogue(quest);
        }

        // Wait for E to be released before re-enabling interaction
        if (!Keyboard.current.eKey.isPressed && !dialogueStarted)
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

        // Update quest progress
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

        dialogueStarted = false;
    }
}
