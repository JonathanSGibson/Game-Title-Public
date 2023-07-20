using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    public string walkName;
    public string idleName;
    public Rigidbody2D rb;
    public Animator anim;

    void animationFunc()
    {
        //Plays an idle animation if the enemy isn't moving, else plays their walking animation (Whilst I only have one enemy type this is set up so it would work with multiple as the names of animations are set in the inspector)
        if (rb.velocity.x == 0)
        {
            anim.Play(idleName);
        }
        else
        {
            anim.Play(walkName);
        }
    }


    void FixedUpdate()
    {
        animationFunc();
    }
}
