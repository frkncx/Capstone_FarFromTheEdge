using UnityEngine;

public class RuneTrigger : MonoBehaviour
{
    public int runeIndex; // 0 = Yellow, 1 = Green

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TryActivateRune(runeIndex);
        }
    }
}
