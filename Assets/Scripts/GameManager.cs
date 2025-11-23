using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    // Area 2 UTILS 
    public int Item2Count { get; set; } = 0;
    public bool Area2Completed { get; set; } = false;

    // Area 3 UTILS
    public int Item3Count { get; set; } = 0;
    public bool QuestCompletedArea3 { get; set; } = false;
    public int PickaxeItem { get; set; } = 1;   
    public int FireOrbItem { get; set; } = 1;
    public bool Quest1ReadytoComplete { get; set; } = false;

    [Header("Area 1 Utilities")]
    public bool BlueOrbItem { get; set; } = false;

    // Effects
    public Image transitionCanvas;

    //TextSpeed for menu settings
    public float textSpeed = 0.01f;

    // 2nd Area Puzzle Completed
    [SerializeField]
    GameObject Pedestal;

    public bool IsPlayedPaused { get; set; } = false;

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

    #region Second Area

    public void CheckArea2()
    {
        if (Pedestal.GetComponent<Pedestal>().PedestalCompleted)
        {
            Area2Completed = true;
        }
    }

    #endregion

    #region Third Area

    public bool CheckArea3Quest()
    {
        if (Item3Count >= 3)
        {
            return QuestCompletedArea3 = true;
        }
        else
        {
            return QuestCompletedArea3 = false;
        }
    }

    #endregion

    #region ENDGAME

    public void GameWon()
    {
        StopAllCoroutines(); // Stop any ongoing fade in/out coroutines
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float currentFadeTime = 0f;
        float fadeOutInSeconds = 3f;
        Color c = transitionCanvas.color;

        if (c.a > 0) currentFadeTime = fadeOutInSeconds * c.a;

        while (currentFadeTime < fadeOutInSeconds)
        {
            currentFadeTime += Time.deltaTime;

            c.a = Mathf.Clamp(currentFadeTime / fadeOutInSeconds, 0f, 2f);

            transitionCanvas.color = c;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(2f);

        LoadGameWonScene();
    }

    private void LoadGameWonScene()
    {
        SceneManager.LoadScene(1);
    }

    #endregion




}
