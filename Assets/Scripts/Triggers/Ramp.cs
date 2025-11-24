using UnityEngine;

public class Ramp : MonoBehaviour
{
    public bool isOpen = false;
    private static readonly int openRampParam = Animator.StringToHash("OpenRamp");
    public Animator animator;
    public GameObject Obstacle;

    private void Update()
    {
        ToggleGate();
    }

    public virtual void ToggleGate()
    {
        if (GameManager.Instance.Area2PedestalCompleted && !isOpen)
        {
            isOpen = true;
            if (Obstacle != null)
                Obstacle.SetActive(false);
            animator.SetTrigger(openRampParam);
        }
    }
}
