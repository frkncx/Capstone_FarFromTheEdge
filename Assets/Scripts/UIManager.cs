using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenu;

    public void OnInventoryToggle(InputAction.CallbackContext context)
    {
        if (context.action.inProgress)
        {
            if (inventoryMenu != null)
            {
                bool isActive = inventoryMenu.activeSelf;
                inventoryMenu.SetActive(!isActive);
            }
        }
    }
}
