using UnityEngine;

public class AltarPedestal : FirePedestal, IPlayerInteractable
{
    private static readonly int recieveParam = Animator.StringToHash("Complete");
    public Animator animator;

    public override void OnPlayerInteraction(Player player)
    {
        base.OnPlayerInteraction(player);

        if (GameManager.Instance.FireOrbItem> 0 && animator != null)
            animator.SetTrigger(recieveParam);

        if (FirePedestalCompleted)
        {
            Debug.Log("Altar Completed");
            HideCue();
        }
    }
}
