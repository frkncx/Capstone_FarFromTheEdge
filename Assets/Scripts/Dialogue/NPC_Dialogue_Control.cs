using UnityEngine;
using UnityEngine.UIElements;

public class NPC_Dialogue_Control : MonoBehaviour
{
    public GameObject dialogueBox;
    
    public DialogueController firstDialogue;
    public DialogueController secondDialogue;
    public DialogueController finalDialogue;

    public bool isFirstDialogue;
    public bool isSecondDialogue;
    public bool isFinalDialogue;

    public bool isQuestComplete;
    public bool isDialogueStarted;


    [Header("Collision settings")] //This I got from my other dialogue videos

    public float dialogueRange;
    public LayerMask playerLayer;
    private Vector3 position;
    public bool playerHit = false;


    void Awake()
    {
        firstDialogue.enabled = false;
        secondDialogue.enabled = false;
        finalDialogue.enabled = false;

        isFirstDialogue = true;
        isSecondDialogue = false;
        isFinalDialogue = false;

        isDialogueStarted = false;
    }

    void Update()
    {
        //IMPORTANT: This is where the dialogue is triggered. Check if we are doing with the input key or by distance, etc.
        //THE LOGIC BELOW NEEDS TO BE TESTED YET, but since I didn't get to use E for it, I wasn't able to test.
        //This full logic intention is to check if it is the first dialogue (giving the quest),
        //the second dialogue (having two buttons in the end to check if quest is completed or not)
        //and the final dialogue that is the one the NPC will keep repeating)
        if (Input.GetKeyDown(KeyCode.E) && playerHit) //It was supposed to have and "Press E" here as well, but I didn't figure out how to do it.
        {
            dialogueBox.SetActive(true);

            if (isFirstDialogue && !isSecondDialogue && !isFinalDialogue && !isDialogueStarted)
            {
                isDialogueStarted = true;
                firstDialogue.enabled = true;
                
                if(firstDialogue.isDialogueOver)
                {
                    isFirstDialogue = false;
                    isSecondDialogue = true;
                    isDialogueStarted = false;
                }
            }

            else if (!isFirstDialogue && isSecondDialogue && !isFinalDialogue && !isDialogueStarted) 
            {
                isDialogueStarted = true;

                secondDialogue.enabled = true;
                if (isQuestComplete && secondDialogue.isDialogueOver)
                {
                    isSecondDialogue = false;
                    isFinalDialogue = true;
                    isDialogueStarted = true;

                }
            }
            
            else if (!isFirstDialogue && !isSecondDialogue && isFinalDialogue && !isDialogueStarted)
            {
                isDialogueStarted = true;

                finalDialogue.enabled = true;

            }

        }
    }

    public void QuestUnfinished() //Button to use that, must be added yet
    {
        isDialogueStarted = false;
        secondDialogue.enabled = false;
    }

    public void QuestFinished() //Button to use that, must be added yet
    {
        //Remove items
        isQuestComplete = true;
    }

    void FixedUpdate()
    {
        ShowDialogue(); //Check if player can start the interaction because it is near
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

    private void OnDrawGizmosSelected() //A visual reference for the collider
    {
        position = transform.position;

        Gizmos.DrawWireSphere(position, dialogueRange);
    }
}
