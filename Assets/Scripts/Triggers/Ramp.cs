using UnityEngine;

public class Ramp : MonoBehaviour
{
    public bool isOpen = false;
    private static readonly int openRampParam = Animator.StringToHash("OpenRamp");
    public Animator animator;

    private void Update()
    {
        ToggleGate();
    }

    public void ToggleGate()
    {
        if (GameManager.Instance.Area2Completed && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openRampParam);
        }
    }
}
