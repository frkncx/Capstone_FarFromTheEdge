using UnityEngine;

public class Item : MonoBehaviour, IPlayerInteractable
{
    // Stats for the items, modify them in the inspector
    [SerializeField] protected float rotateSpeed = 90f;
    [SerializeField] protected string itemName = "Item";

    private void Update()
    {
        // rotate automatically without the need for animation
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Destory the item on interaction with the player
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerInteraction(Player player)
    {
        Debug.Log($"{itemName} Collected");
        Destroy(gameObject);
    }
}
