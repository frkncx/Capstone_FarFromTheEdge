using UnityEngine;

public class QuestItem : Item, IPlayerInteractable
{
    /// <summary>
    /// Destory the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        Debug.Log($"{itemName} Collected");
        GameManager.Instance.QuestItem1Collected = true;
        Destroy(transform.parent.gameObject);
        
    }
}
