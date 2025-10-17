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
        if (GameManager.Instance.Item1Count == 3 && GameManager.Instance.Item2Count == 3 && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openRampParam);
        }
    }
}
