using UnityEngine;

public class Item1 : Item, IPlayerInteractable
{
    /// <summary>
    /// Destory the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        Debug.Log($"{itemName} Collected");
        Destroy(gameObject);
        Destroy(EVisualCue);
        GameManager.Instance.PedalItemCount++;
    }
}
