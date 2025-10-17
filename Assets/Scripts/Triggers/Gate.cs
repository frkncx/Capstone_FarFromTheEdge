using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    private static readonly int openParam = Animator.StringToHash("OpenSesame");
    public Animator animator;

    private void Update()
    {
        ToggleGate();
   }

    public void ToggleGate()
    {
        if (GameManager.Instance.QuestItem1Collected && !isOpen)
        {
            isOpen = true;
            animator.SetTrigger(openParam);
        }
    }
} 
