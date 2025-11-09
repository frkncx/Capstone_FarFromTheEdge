using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    Animator animator; //Change the state

    // Condition is the tag text where we will put the tags for the different equipments.The text will address which tag should be compared and then trigger the puzzle manager.
    public string condition;

    //Puzzle IDs should go from 0 to 4 (puzzles 1 to 5)
    public int puzzleID;

    //Prevents the puzzle to work twice
    bool puzzleActive;

    private void Start()
    {
        animator = GetComponent<Animator>();
        puzzleActive = false;
        PuzzleManager.Instance.AddPiece(this, puzzleID);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(condition) && !puzzleActive)
        {
            animator.SetBool("Complete", true); 
            PuzzleManager.Instance.PuzzlePieceActivated(puzzleID);
            puzzleActive = true;
        }
        else return;
    }
}
