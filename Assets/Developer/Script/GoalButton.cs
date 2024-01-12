using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    public bool select;

    public void Select()
    {
        if (!select)
        {
            animator.SetTrigger("Select");
        }
        else
        {
            animator.SetTrigger("Deselect");
        }

        select = !select; 
    }
    
}
