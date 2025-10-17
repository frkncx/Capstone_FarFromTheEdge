using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Item1Count { get; set; } = 0;
    public int Item2Count { get; set; } = 0;
    public bool QuestItem1Collected { get; set; } = false;
    public bool Area2Completed { get; set; } = false;

    /// <summary>
    /// Pause the Game on pressing ESC, Attached to Player Input 
    /// </summary>
    public void PauseMenuManager()
    {
        if (Time.timeScale == 1f)
        {

            if (GameObject.FindGameObjectWithTag("PauseMenu") == null)
            {
                Instantiate(Resources.Load("PauseMenu"));
            }

            // Pause
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {

            // Destroy the pause menu
            Destroy(GameObject.FindGameObjectWithTag("PauseMenu"));

            // Resume 
            Time.timeScale = 1f;
        }
    }

    #region First Area

    

    #endregion
}
