using UnityEngine;

public class Item3 : Item, IPlayerInteractable
{
    /// <summary>
    /// Destory the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        Debug.Log($"{itemName} Collected");
        Destroy(transform.parent.gameObject);
        GameManager.Instance.Item3Count++;
    }
}