using System.Collections;
using UnityEngine;

public class LeverPedestal : Pedestal, IPlayerInteractable
{
    private static readonly int activateParam = Animator.StringToHash("Active");
    public Animator animator;

    public bool isActivated = false;

    public bool LevelPedestalCompleted => AllItemsActive();

    public override bool AllItemsActive()
    {
        if (itemsToDisplay[0].activeSelf)
            return true;
        else
            return false;
    }

    protected override void UpdateItemsToShow()
    {
        if (isActivated)
        {
            itemsToDisplay[0].SetActive(true);
        }
        else
        {
            itemsToDisplay[0].SetActive(false);
        }
    }

    public override void OnPlayerInteraction(Player player)
    {
        if (isActivated)
        {
            return;
        }

        if (animator != null)
            animator.SetTrigger(activateParam);

        StartCoroutine(ResetActivation(12f));    
    }

    /// <summary>
    /// This is the reset logic for the lever pedestal after 12s
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator ResetActivation(float time)
    {
        isActivated = true;
        UpdateItemsToShow();
        HideCue();

        yield return new WaitForSeconds(time);
        
        isActivated = false;
        UpdateItemsToShow();
        ShowCue();
    }
}
