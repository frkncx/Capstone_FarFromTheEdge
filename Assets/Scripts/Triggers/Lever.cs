using UnityEngine;

public enum LeverParam
{
    Complete,
    Trigger1, Trigger2, Trigger3, Trigger4, Trigger5,
    None
}

public class Lever : MonoBehaviour, IPlayerInteractable
{
    public LeverParam currentParam;
    public Animator animator;
    public bool isActivated = false;
    public bool repeatable = false;

    // Visual cue popup
    [SerializeField] private GameObject EVisualCue;

    public bool cueVisible = false;

    public void OnPlayerInteraction(Player player)
    {
        // Implement lever interaction logic here
        if (animator != null)
            animator.SetTrigger(currentParam.ToString());

        if (!repeatable)
            isActivated = true;
    }

    public void ShowCue()
    {
        if (EVisualCue != null)
            EVisualCue.SetActive(true);
    }

    public void HideCue()
    {
        if (EVisualCue != null)
            EVisualCue.SetActive(false);
    }
}
