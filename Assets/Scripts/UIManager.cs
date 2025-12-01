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

    [SerializeField]
    private GameObject[] equipmentAffordables;

    // Inventory Item Counts
    [SerializeField]
    private TMP_Text item1Count, Item3Count;

    // When no items, disable slot game objects
    [SerializeField]
    private GameObject[] slots;

    private void Update()
    {
        item1Count.text = GameManager.Instance.PedalItemCount.ToString("D1");
        Item3Count.text = GameManager.Instance.OreItemCount.ToString("D1");

        UpdateEquipments();
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

    public void HasPickaxeEquipped()
    {
        if (GameManager.Instance.PickaxeItem < 1)
        {
            return;
        }
        GameManager.Instance.HasPickaxeEquipped = true;
        GameManager.Instance.HasFireOrbEquipped = false;
        equipmentAffordables[0].SetActive(true);
        equipmentAffordables[1].SetActive(false);
    }

    public void HasFireOrbEqipped()
    {
        if (GameManager.Instance.FireOrbItem < 1)
        {
            return;
        }

        GameManager.Instance.HasFireOrbEquipped = true;
        GameManager.Instance.HasPickaxeEquipped = false;
        equipmentAffordables[1].SetActive(true);
        equipmentAffordables[0].SetActive(false);
    }

    void UpdateEquipments()
    {
        if (GameManager.Instance.PickaxeItem == 1)
        {
            EquipmentItems[0].SetActive(true);
        }
        else
        {
            EquipmentItems[0].SetActive(false);
        }

        if (GameManager.Instance.FireOrbItem == 1)
        {
            EquipmentItems[1].SetActive(true);
        }
        else
        {
            EquipmentItems[1].SetActive(false);
        }    
    }

    void UpdateSlots()
    {
        if (GameManager.Instance.PedalItemCount < 1)
        {
            slots[0].SetActive(false);
        }
        else
        {
            slots[0].SetActive(true);
        }

        if (GameManager.Instance.OreItemCount < 1)
        {
            slots[1].SetActive(false);
        }
        else
        {
            slots[1].SetActive(true);
        }
    }
}
