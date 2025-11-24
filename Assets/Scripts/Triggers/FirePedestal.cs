using UnityEngine;

public class FirePedestal : Pedestal, IPlayerInteractable
{
    public bool FirePedestalCompleted => AllItemsActive();

    private void Start()
    {
        //UpdateItemsToShow();
    }

    protected override void UpdateItemsToShow()
    {
        if (GameManager.Instance.FireOrbItem > 0)
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
        if (GameManager.Instance.FireOrbItem <= 0)
        {
            return;
        }

        UpdateItemsToShow();

        GameManager.Instance.CheckArea3();

        if (FirePedestalCompleted)
        {
            Debug.Log("Fire Pedestal Completed");
            HideCue();
        }
    }
}
