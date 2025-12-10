using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Pedestal : MonoBehaviour, IPlayerInteractable
{
    [Header("Pedestal Features")]
    [SerializeField] protected GameObject[] itemsToDisplay; // items to show on the pedestal

    //[Tooltip("Select a Type if you want Item 1 or Item 2 to interact with Pedestal")]
    //public int pedestalType; // for item 1 or 2
    public bool cueVisible = false;

    private int collectedCount = 0; // number of items collected

    public bool PedestalCompleted => AllItemsActive();

    // Visual cue popup
    [SerializeField] public GameObject EVisualCue;

    private void Start()
    {
        UpdateItemsToShow();
    }

    protected virtual void UpdateItemsToShow()
    {
        // Check each itemDisplay game objects and activate based on collected items
        for (int i = 0; i < itemsToDisplay.Length; i++) 
        { 
            itemsToDisplay[i].SetActive(i < collectedCount); 
        }
    }

    public virtual bool AllItemsActive()
    {
        foreach (GameObject item in itemsToDisplay)
        {
            if (!item.activeSelf)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Utilize the method by adding the item to the pedestal
    /// </summary>
    /// <param name="player"></param>
    public virtual void OnPlayerInteraction(Player player)
    {
        if (GameManager.Instance.PedalItemCount > 0)
        {
            GameManager.Instance.PedalItemCount--;
            collectedCount++;
        }

        // Display items 
        UpdateItemsToShow();

        GameManager.Instance.CheckArea2();
    }

    public void ShowCue()
    {
        if (cueVisible) return;

        cueVisible = true;
        if (EVisualCue != null)
            EVisualCue.SetActive(true);
    }

    public void HideCue()
    {
        if (!cueVisible) return;

        cueVisible = false;
        if (EVisualCue != null)
            EVisualCue.SetActive(false);
    }
}
