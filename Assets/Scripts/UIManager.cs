using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    // Toggle Backpack
    [SerializeField]
    private GameObject inventoryMenu;
    private static readonly int closeBackPack = Animator.StringToHash("CloseBackpack");
    private static readonly int openBackPack = Animator.StringToHash("OpenBackpack");
    public Animator animator;
    bool isActive = true;

    // Equipment items in the equipment menu
    [SerializeField]
    private List<GameObject> EquipmentItems;

    // Inventory Item Counts
    [SerializeField]
    private TMP_Text item1Count, Item3Count;

    // When no items, disable slot game objects
    [SerializeField]
    private GameObject[] slots;

    private void Update()
    {
        item1Count.text = GameManager.Instance.Item1Count.ToString("D1");
        //item2Count.text = GameManager.Instance.Item2Count.ToString("D1");
        Item3Count.text = GameManager.Instance.Item3Count.ToString("D1");

        UpdateQuestItems();
        UpdateSlots();
    }

    public void ToggleInventoryBackpack()
    {
        if (inventoryMenu != null)
        {
            // Reset both triggers before setting the desired one to avoid overlap
            animator.ResetTrigger(closeBackPack);
            animator.ResetTrigger(openBackPack);

            if (isActive)
            {
                animator.SetTrigger(closeBackPack);
                isActive = false;
            }
            else
            {
                animator.SetTrigger(openBackPack);
                isActive = true;
            }
        }
    }

    void UpdateQuestItems()
    {
        // Add Item Icon to the inventory
        if (GameManager.Instance.QuestItem1Collected)
        {
            EquipmentItems[0].SetActive(true);
        }

        if (GameManager.Instance.MagicItem == 1)
        {
            EquipmentItems[1].SetActive(true);
        }
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

        if (GameManager.Instance.Item3Count < 1)
        {
            slots[1].SetActive(false);
        }
        else
        {
            slots[1].SetActive(true);
        }
    }
}
