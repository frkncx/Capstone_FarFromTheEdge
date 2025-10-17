using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [Header("Pedestal Features")]
    [SerializeField] GameObject[] itemsToDisplay; // items to show on the pedestal

    [Tooltip("Select a Type if you want Item 1 or Item 2 to interact with Pedestal")]
    public int pedestalType; // for item 1 or 2

    private int collectedCount = 0; // number of items collected

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateItemsToShow();
    }

    private void UpdateItemsToShow()
    {
        //For either item1 or item2
        switch (pedestalType)
        {
            case 1:
                if (GameManager.Instance.Item1Count > collectedCount)
                {
                    collectedCount++;
                }
                break;
            case 2:
                if (GameManager.Instance.Item2Count > collectedCount)
                {
                    collectedCount++;
                }
                break;
            default:
                return;
        }

        // Check each itemDisplay game objects and activate based on collected items
        for (int i = 0; i < itemsToDisplay.Length; i++) 
        { 
            itemsToDisplay[i].SetActive(i < collectedCount); 
        }
    }

    ///// <summary>
    ///// Utilize the method by adding the item to the pedestal
    ///// </summary>
    ///// <param name="player"></param>
    //public void OnPlayerInteraction(Player player)
    //{
    //    // For either item1 or item2
    //    switch (pedestalType)
    //    {
    //        case 1:
    //            if (GameManager.Instance.Item1Count > 0)
    //            {
    //                GameManager.Instance.Item1Count--;
    //                collectedCount++;
    //            }
    //            break;
    //        case 2:
    //            if (GameManager.Instance.Item2Count > 0)
    //            {
    //                GameManager.Instance.Item2Count--;
    //                collectedCount++;
    //            }
    //            break;
    //        default:
    //            return;
    //    }
        
    //    // Use Method here
    //    UpdateItemsToShow();
    //}
}
