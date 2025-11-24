using UnityEngine;

public class GreenOrbItem : Item, IPlayerInteractable
{
    /// <summary>
    /// Get the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        Debug.Log($"{itemName} Collected");
        GameManager.Instance.GreenOrbItem = true;
        Destroy(transform.parent.gameObject);

    }
}
