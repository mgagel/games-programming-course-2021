using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{

    public Animator animator;
    public FixedEnemyMovement movement;

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("lookingDirection", movement.lookingDirection);
        if (movement.startDestroyTimer)
        {
            animator.SetTrigger("explosion");
        }
    }
}
