using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

    private void Update()
    {

    }

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
}
