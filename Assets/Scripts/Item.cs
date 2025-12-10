using UnityEngine;

public class Item : MonoBehaviour
{
    // Stats for the items, modify them in the inspector
    [SerializeField] protected float rotateSpeed = 90f;
    [SerializeField] protected string itemName;

    // Visual cue popup
    [SerializeField] protected GameObject EVisualCue;

    public bool cueVisible = false;

    private void Update()
    {
        // rotate automatically without the need for animation
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    // These two methods will be called by Player
    public void ShowCue()
    {
        if (cueVisible) return;

        cueVisible = true;
        if (EVisualCue != null)
            EVisualCue.SetActive(true);
    }

    public void HideCue()
    {
        if (!cueVisible) return;

        cueVisible = false;
        if (EVisualCue != null)
            EVisualCue.SetActive(false);
    }
}
