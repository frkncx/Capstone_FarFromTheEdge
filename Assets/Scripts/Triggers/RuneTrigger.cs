using UnityEngine;

public class RuneTrigger : MonoBehaviour
{
    public int runeIndex; // 0 = Yellow, 1 = Green
    public Light pointLight;

    private void Update()
    {
        if (GameManager.Instance.progress > runeIndex)
        {
            pointLight.gameObject.SetActive(true);
        }
        else
        {
            pointLight.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TryActivateRune(runeIndex);
        }
    }
}
