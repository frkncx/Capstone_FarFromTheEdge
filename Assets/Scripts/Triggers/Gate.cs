using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    private static readonly int openParam = Animator.StringToHash("Open");
    public Animator animator;

    private void Update()
    {
        ToggleGate();
   }

    public void ToggleGate()
    {
        if (GameManager.Instance.BlueOrbItem && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openParam);
        }
    }
} 
