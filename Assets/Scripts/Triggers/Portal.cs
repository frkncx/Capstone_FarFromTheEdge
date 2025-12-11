using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Mirror;

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.CheckArea71();
        GameManager.Instance.CheckArea72();

        if (GameManager.Instance.CheckArea71() && GameManager.Instance.CheckArea72())
        {
            Mirror.SetActive(false);
        }
        else
        {
            Mirror.SetActive(true);
        }
    }
}
