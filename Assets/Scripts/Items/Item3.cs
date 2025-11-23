using UnityEngine;

public class Item3 : Item, IPlayerInteractable
{
    /// <summary>
    /// Destory the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        if (GameManager.Instance.PickaxeItem <= 0)
        {
            EVisualCue.SetActive(false);
            Debug.Log("You need a pickaxe to collect this item.");
            return;
        }

        Debug.Log($"{itemName} Collected");
        Destroy(transform.parent.gameObject);
        Destroy(EVisualCue);
        GameManager.Instance.Item3Count++;
    }
}