using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour, IPlayerInteractable
{
    public bool isOpen = false;
    private static readonly int openParam = Animator.StringToHash("Open");
    public Animator animator;

    public virtual void ToggleGate()
    {
        if (GameManager.Instance.BlueOrbItem && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openParam);
        }
    }

    public void OnPlayerInteraction(Player player)
    {
        ToggleGate();
    }
} 
