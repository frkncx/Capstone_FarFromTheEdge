using UnityEngine;

public class PortalTestScript : MonoBehaviour
{
    Collider col;
    public Transform newPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = newPosition.position;
    }
}
