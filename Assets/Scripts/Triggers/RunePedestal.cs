using UnityEngine;

public class RunePedestal : MonoBehaviour
{
    private static readonly int activateParam = Animator.StringToHash("Complete");
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Area6PuzzleCompleted)
        {
            animator.SetTrigger(activateParam);
        }
    }
}
