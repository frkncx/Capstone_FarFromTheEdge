using UnityEngine;

public class Altar : Pedestal, IPlayerInteractable
{
    public enum AltarType
    {
        Ore,
        Pedal
    }

    public AltarType altarType;

    public override void OnPlayerInteraction(Player player)
    {
        switch (altarType)
        {
            case AltarType.Ore:
                if (GameManager.Instance.OreItemCount > 0)
                {
                    GameManager.Instance.OreItemCount--;
                }
                break;
            case AltarType.Pedal:
                if (GameManager.Instance.PedalItemCount > 0)
                {
                    GameManager.Instance.PedalItemCount--;
                }
                break;
        }

        UpdateItemsToShow();
    }
}
