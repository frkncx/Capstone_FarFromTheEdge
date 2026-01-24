using UnityEngine;

public class OrbScript : MonoBehaviour
{
    Collider col;
    public GameObject orb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        orb.SetActive(false);    
    }
}
