using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    [Header("Camera Utils")]
    // Assign the Player Transform in the Inspector
    public Transform player;
    Vector3 currentVelocity;

    // Values to adjust in the Inspector
    public float distance = 25;
    public float height = 45;
    public float smoothTime = 0.25f;

    

    void LateUpdate()
    {
        // Target the player's position and transform camera accordingly
        Vector3 target = new Vector3(player.position.x, height, player.position.z - distance);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);;
    }
}
