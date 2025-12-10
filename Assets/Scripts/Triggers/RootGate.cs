using UnityEngine;

public class RootGate : Gate, IPlayerInteractable
{
    private static readonly int removeParam = Animator.StringToHash("Complete");

    public override void ToggleGate()
    {
        // break instead of open
        if (GameManager.Instance.GreenOrbItem == 1 && GameManager.Instance.HasGreenOrbEquipped)
        {
            animator.SetTrigger(removeParam);
        }
    }
}
