using UnityEngine;

public class BreakableGate : Gate, IPlayerInteractable
{
    private static readonly int openParam = Animator.StringToHash("Break");

    public override void ToggleGate()
    {
        // break instead of open
        if (GameManager.Instance.HasPickaxeEquipped && GameManager.Instance.PickaxeItem > 0 && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openParam);
        }
    }
}
