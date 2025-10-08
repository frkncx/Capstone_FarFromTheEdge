using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Mobility and Movement Utils")]
    public Rigidbody rb;
    Vector3 moveDirection;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    [Header("Player Stats")]
    // Don't adjust here, use the Player Component in the Inspector
    public int moveSpeed = 10;

    [Header("Item Utils")]
    [SerializeField] private Image eShortCutCue;
    private IPlayerInteractable nearbyInteractable;

    // Animation Utils
    private static readonly int collectParam = Animator.StringToHash("PlayerCollect");
    private bool isPaused = false;

    private void Start()
    {
        eShortCutCue.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Stop movement when paused
        if (isPaused)
        {
            //rb.linearVelocity = Vector3.zero;
            //animator.SetFloat("MoveSpeed", 0f);
            return;
        }

        // This is an Movement implementation for Unity's Input System
        Vector2 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.y);

        // Flip the player sprite based on movement direction
        GetFacingDirection(-moveDirection.x);

        #region Animation Control

        // Check anim
        if (animator == null) return;

        // Use XZ speed for blend tree
        float speed = new Vector2(moveDirection.x, moveDirection.y).magnitude;

        // Set Animation Speed (For the Blend Tree)
        animator.SetFloat("MoveSpeed", speed, 0.1f, Time.fixedDeltaTime);

        #endregion
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

    #region Collecting Items

    /// <summary>
    ///  Collect Items BOI by Pressing E
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.action.inProgress && nearbyInteractable != null && !isPaused)
        {
            isPaused = true;

            animator.SetTrigger(collectParam);
            nearbyInteractable.OnPlayerInteraction(this);
            eShortCutCue.gameObject.SetActive(false);

            StartCoroutine(ResumeAfterPause(0.7540984f));
        }
        else
        {
            Debug.Log("No interactable nearby or already interacting.");
        }
    }

    /// <summary>
    /// Resume after the pause state
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    IEnumerator ResumeAfterPause(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPaused = false;
    }

    /// <summary>
    /// Visual Cue pop up BOIs
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out IPlayerInteractable interactable))
        {
            nearbyInteractable = interactable;
            eShortCutCue.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Disable Visual Cue when nearby items are missing (collected)
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayerInteractable interactable) && interactable == nearbyInteractable)
        {
            nearbyInteractable = null;
            eShortCutCue.gameObject.SetActive(false);
        }
    }

    #endregion

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (context.action.inProgress)
        {
            // Implement inventory opening logic here
            Debug.Log("Inventory opened (functionality to be implemented).");
        }
    }
}

