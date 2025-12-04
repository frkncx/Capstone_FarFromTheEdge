using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Area 1 Utilities")]
    public bool BlueOrbItem { get; set; } = false;

    // Area 2 UTILS 
    public int PedalItemCount { get; set; } = 0;
    public bool Area2PedestalCompleted { get; set; } = false;

    // Area 3 UTILS
    public int OreItemCount { get; set; } = 0;
    public bool Quest1Completed { get; set; } = false;
    public int PickaxeItem { get; set; } = 1;   
    public int FireOrbItem { get; set; } = 1;
    public bool Quest1ReadytoComplete { get; set; } = false;
    public bool Area3PedestalCompleted { get; set; } = false;

    // Area 4 UTILS
    public bool GreenOrbItem { get; set; } = false;

    // Area 5 UTILS

    // Area 6 UTILS
    public bool SightAbilityUnlocked { get; set; } = false;
    public bool Quest2ReadytoComplete { get; set; } = false;
    public bool Quest2Completed { get; set; } = false;
    public bool Area6PuzzleCompleted { get; set; } = false;
    public int[] correctOrder = { 0, 1, 2, 3 };
    private int progress = 0;

    // Area 7 UTILS
    public bool Area1Set { get; set; } = false;
    public bool Area2Set { get; set; } = false;

    // ----------------------------

    // 2nd Area Puzzle Completed
    [SerializeField]
    GameObject Pedestal;

    // 3rd Area Puzzle Completed
    [SerializeField]
    GameObject FirePedestal;

    // 4th area puzzle completed
    [SerializeField]
    GameObject AltarPedestal;

    // Effects
    public Image transitionCanvas;

    //TextSpeed for menu settings
    public float textSpeed = 0.01f;

    // Pause Player State
    public bool IsPlayedPaused { get; set; } = false;

    // Equipment Utils
    public bool HasPickaxeEquipped { get; set; } = false;
    public bool HasFireOrbEquipped { get; set; } = false;

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
            Area2PedestalCompleted = true;
        }
    }

    #endregion

    #region Third Area

    public bool CheckArea3Quest()
    {
        if (OreItemCount >= 3)
        {
            return Quest1Completed = true;
        }
        else
        {
            return Quest1Completed = false;
        }
    }

    // Fire Pedestal for Now
    public void CheckArea3()
    {
        if (FirePedestal.GetComponent<FirePedestal>().FirePedestalCompleted)
        {
            Area3PedestalCompleted = true;
        }
    }

    #endregion

    #region Fourth Area

    public bool CheckArea4Quest()
    {
        if (PedalItemCount >= 8 && OreItemCount >= 6)
        {
            return Quest2Completed = true;
        }
        else
        {
            return Quest2Completed = false;
        }
    }

    #region 6th Area

    public void TryActivateRune(int runeIndex)
    {
        // Player hit the correct next rune
        if (runeIndex == correctOrder[progress])
        {
            Debug.Log("Correct Rune: " + runeIndex);
            progress++;

            //(runeIndex);

            // Check if puzzle solved
            if (progress >= correctOrder.Length)
            {
                GameManager.Instance.Area6PuzzleCompleted = true;
                Debug.Log("Grats");
            }
        }
        else
        {
            Debug.Log("Wrong Rune, Resetting puzzle");
            progress = 0;
        }
    }

    #endregion

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
