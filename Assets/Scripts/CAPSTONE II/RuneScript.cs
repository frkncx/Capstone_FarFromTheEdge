using UnityEngine;

public class RuneScript : MonoBehaviour
{
    Collider col;
    Animator anim;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetBool("Active") == true)
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                anim.SetBool("Active", false);
                timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Active", true);
    }

}
