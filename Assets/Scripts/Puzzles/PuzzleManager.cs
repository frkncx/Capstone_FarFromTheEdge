using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.ProBuilder.Shapes;
using Unity.Burst.CompilerServices;

public class PuzzleManager : MonoBehaviour
{
    /// <summary>
    /// The lists are for the puzzle pieces to be added automatically by the PuzzlePiece script.
    /// The index is to compare the length of the puzzle with the current index to let the system knows the puzzle was completed.
    /// </summary>
    
    public List<PuzzlePiece> puzzle1Pieces;
    public int puzzle1Index;

    public List<PuzzlePiece> puzzle2Pieces;
    public int puzzle2Index;

    public List<PuzzlePiece> puzzle3Pieces;
    public int puzzle3Index;

    public List<PuzzlePiece> puzzle4Pieces;
    public int puzzle4Index;

    public List<PuzzlePiece> puzzle5Pieces;
    public int puzzle5Index;

    public Animator[] puzzleComplete;



    static PuzzleManager instance;

    public static PuzzleManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Separates the puzzle pieces by ID and adds to the list
    /// </summary>
    /// <param name="piece">Script attached to a game object</param>
    /// <param name="puzzleID">Numbers from 0 to 4 referring the puzzle ID || ID 0 is the puzzle 1, ID 1 is puzzle 2 and the same applies to all others</param>
    public void AddPiece(PuzzlePiece piece, int puzzleID)
    {
        if (puzzleID == 0)
        {
            puzzle1Pieces.Add(piece);
        }

        if (puzzleID == 1)
        {
            puzzle2Pieces.Add(piece);
        }

        if (puzzleID == 2)
        {
            puzzle3Pieces.Add(piece);
        }

        if (puzzleID == 3)
        {
            puzzle4Pieces.Add(piece);
        }

        if (puzzleID == 4)
        {
            puzzle5Pieces.Add(piece);
        }
    }

    //Every time a puzzle piece suffers an interaction, it adds the number here, and if the number is equal to the amount of pieces required, the puzzle is solved.
    public void PuzzlePieceActivated(int puzzleID)
    {
        if (puzzleID == 0)
        {
            puzzle1Index++;

            if (puzzle1Index == puzzle1Pieces.Count)
            {
                PuzzleComplete(puzzleID);
                //Debug.Log("PuzzleCount works");

            }
        }

        if (puzzleID == 1)
        {
            puzzle2Index++;

            if (puzzle2Index == puzzle2Pieces.Count)
            {
                PuzzleComplete(puzzleID);
            }
        }

        if (puzzleID == 2)
        {
            puzzle3Index++;

            if (puzzle3Index == puzzle3Pieces.Count)
            {
                PuzzleComplete(puzzleID);
            }
        }

        if (puzzleID == 3)
        {
            puzzle4Index++;

            if (puzzle4Index == puzzle4Pieces.Count)
            {
                PuzzleComplete(puzzleID);
            }
        }

        if (puzzleID == 4)
        {
            puzzle5Index++;

            if (puzzle5Index == puzzle5Pieces.Count)
            {
                PuzzleComplete(puzzleID);
            }
        }


    }

    //The piece where the puzzle is completed must be referenced by it's animator into the index. This way, the puzzle ID will reflect the puzzle piece that will move for it to be complete.
    public void PuzzleComplete(int puzzleID)
    {    
        puzzleComplete[puzzleID].SetBool("Complete", true);
        Debug.Log("FunctionCalled - PuzzleComplete");
    }
}
