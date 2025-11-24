using UnityEngine;

public class BridgeRamp : Ramp
{
    private static readonly int openRampParam = Animator.StringToHash("Complete");

    private void Update()
    {
        ToggleGate();
    }

    public override void ToggleGate()
    {
        if (GameManager.Instance.Area3PedestalCompleted && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openRampParam);
            if (Obstacle != null)
                Obstacle.SetActive(false);
        }
    }
}
