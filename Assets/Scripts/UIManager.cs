using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenu;

    // Quest items in the inventory menu
    public List<GameObject> QuestItems;

    [SerializeField]
    private TMP_Text item1CountText, item2CountText;

    private void Update()
    {
        item1CountText.text = GameManager.Instance.Item1Count.ToString("D1");
        item2CountText.text = GameManager.Instance.Item2Count.ToString("D1");

        UpdateQuestItems();
    }

    public void ToggleInventoryMenu()
    {
        if (inventoryMenu != null)
        {
            bool isActive = inventoryMenu.activeSelf;
            inventoryMenu.SetActive(!isActive);
        }
    }

    public void UpdateQuestItems()
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

    /// <summary>
    /// This is for the inventory menu button with X on it
    /// </summary>
    public void QuitInventory()
    {
        if (inventoryMenu != null)
        {
            inventoryMenu.SetActive(false);
        }
    }
}
