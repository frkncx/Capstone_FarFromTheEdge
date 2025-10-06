using UnityEngine;

public class CameraDolly : MonoBehaviour
{
    public Transform player;
    public float distance = 25;
    public float height = 45;
    public float smoothTime = 0.25f;

    Vector3 currentVelocity;

    void LateUpdate()
    {
        // Adjust distance and height by scrolling
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            distance -= scrollInput * 15;
            distance = Mathf.Clamp(distance, 25, 50);

            height -= scrollInput * 15f;
            height = Mathf.Clamp(height,45, 90);

        }

        Vector3 target = new Vector3(player.position.x, height, player.position.z - distance);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);;
    }
}
