using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    [Header("Camera Utils")]
    // Assign the Player Transform in the Inspector
    public Transform player;
    Vector3 currentVelocity;

    // Values to adjust in the Inspector
    public float distance = 25f;
    public float height = 45f;
    public float offSet = 5f;
    public float smoothTime = 0.25f;

    

    void LateUpdate()
    {
        // Target the player's position and transform camera accordingly
        Vector3 target = new Vector3(player.position.x + offSet, height, player.position.z - distance);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}
