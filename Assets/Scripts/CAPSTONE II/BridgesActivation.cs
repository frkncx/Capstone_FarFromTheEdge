using UnityEngine;

public class BridgesActivation : MonoBehaviour
{
    Collider col;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Bridge");
    }
}
