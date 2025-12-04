using UnityEngine;

public class Altar : Pedestal, IPlayerInteractable
{
    public enum AltarType
    {
        Ore,
        Pedal
    }

    public AltarType altarType;
    public bool isActivated = false;    

    private void Start()
    {
        UpdateItemsToShow();
    }

    protected override void UpdateItemsToShow()
    {
        if (isActivated)
        {
            itemsToDisplay[0].SetActive(true);
        }
        else
        {
            itemsToDisplay[0].SetActive(false);
        }
    }

    public override bool AllItemsActive()
    {
        if (itemsToDisplay[0].activeSelf)
            return true;
        else
            return false;
    }

    public override void OnPlayerInteraction(Player player)
    {
        if (isActivated)
        {
            return;
        }

        switch (altarType)
        {
            case AltarType.Ore:
                if (GameManager.Instance.OreItemCount > 0)
                {
                    GameManager.Instance.OreItemCount--;
                    isActivated = true;
                }
                break;
            case AltarType.Pedal:
                if (GameManager.Instance.PedalItemCount > 0)
                {
                    GameManager.Instance.PedalItemCount--;
                    isActivated = true;
                }
                break;
        }

        UpdateItemsToShow();
    }
}
