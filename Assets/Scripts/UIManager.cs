using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    // Toggle Menu Itself, not needed rn
    //[SerializeField]
    //private GameObject inventoryMenu;

    // Quest items in the inventory menu
    [SerializeField]
    private List<GameObject> QuestItems;

    // Inventory Item Counts
    [SerializeField]
    private TMP_Text item1Count, item2Count;

    // When no items, disable slot game objects
    [SerializeField]
    private GameObject[] slots;

    private void Update()
    {
        item1Count.text = GameManager.Instance.Item1Count.ToString("D1");
        item2Count.text = GameManager.Instance.Item2Count.ToString("D1");

        UpdateQuestItems();
        UpdateSlots();
    }

    //public void ToggleInventoryMenu()
    //{
    //    if (inventoryMenu != null)
    //    {
    //        bool isActive = inventoryMenu.activeSelf;
    //        inventoryMenu.SetActive(!isActive);
    //    }
    //}

    void UpdateQuestItems()
    {
        // Add Item Icon to the inventory
        if (GameManager.Instance.QuestItem1Collected)
        {
            QuestItems[0].SetActive(true);
        }

        //if (GameManager.Instance.QuestItem2Collected)
        //{
        //    QuestItems[1].SetActive(true);
        //}
    }

    void UpdateSlots()
    {
        if (GameManager.Instance.Item1Count < 1)
        {
            slots[0].SetActive(false);
        }
        else
        {
            slots[0].SetActive(true);
        }

        if (GameManager.Instance.Item2Count < 1)
        {
            slots[1].SetActive(false);
        }
        else
        {
            slots[1].SetActive(true);
        }
    }

    ///// <summary>
    ///// This is for the inventory menu button with X on it
    ///// </summary>
    //public void QuitInventory()
    //{
    //    if (inventoryMenu != null)
    //    {
    //        inventoryMenu.SetActive(false);
    //    }
    //}
}
