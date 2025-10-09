using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventoryMenu()
    {
        if (inventoryMenu != null)
        {
            bool isActive = inventoryMenu.activeSelf;
            inventoryMenu.SetActive(!isActive);
        }
    }

    public void OnInventoryToggle(InputAction.CallbackContext context)
    {
        if (context.action.inProgress)
        {
            ToggleInventoryMenu();
        }
    }
}
