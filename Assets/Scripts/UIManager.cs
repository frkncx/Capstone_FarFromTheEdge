using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenu;

    [SerializeField]
    private TMP_Text item1CountText, item2CountText;

    private void Update()
    {
        item1CountText.text = GameManager.Instance.Item1Count.ToString("D1");
        item2CountText.text = GameManager.Instance.Item2Count.ToString("D1");
    }

    public void ToggleInventoryMenu()
    {
        if (inventoryMenu != null)
        {
            bool isActive = inventoryMenu.activeSelf;
            inventoryMenu.SetActive(!isActive);
        }
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
