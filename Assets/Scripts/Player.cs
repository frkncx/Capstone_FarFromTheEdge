using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Mobility and Movement Utils")]
    public Rigidbody rb;
    Vector3 moveDirection;
    public SpriteRenderer spriteRenderer;

    [Header("Player Stats")]
    // Don't adjust here, use the Player Component in the Inspector
    public int moveSpeed = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is an Movement implementation for Unity's Input System
        Vector2 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.y);

        // Flip the sprite based on movement direction
        GetFacingDirection(-moveDirection.x);
    }

    /// <summary>
    /// Method that flips the player sprite based on direction
    /// </summary>
    /// <param name="moveDirection"></param>
    /// <returns></returns>
    private float GetFacingDirection(float moveDirection)
    {
        if (moveDirection > 0)
        {
            spriteRenderer.flipX = false;
            return 1f;
        }
        else if (moveDirection < 0)
        {
            spriteRenderer.flipX = true;
            return -1f;
        }

        return 0f;
    }

    /// <summary>
    /// Called in Player's "Player Input" Component to move
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.action.inProgress)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else moveDirection = Vector3.zero;
    }
}

