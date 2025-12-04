using UnityEngine;

public enum LeverParam
{
    Complete,
    Trigger1, Trigger2, Trigger3, Trigger4, Trigger5
}

public class Lever : MonoBehaviour, IPlayerInteractable
{
    public LeverParam currentParam;
    public Animator animator;
    public bool isActivated = false;

    // Visual cue popup
    [SerializeField] private GameObject EVisualCue;

    public void OnPlayerInteraction(Player player)
    {
        // Implement lever interaction logic here
        animator.SetTrigger(currentParam.ToString());
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
