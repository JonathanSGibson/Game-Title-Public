using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // Start is called before the first frame update

    enum playerState
    {
        //Used to track what animation should be playing
        Idle,
        WalkLeft,
        WalkRight,
        Jump,
    }

    enum direction
    {
        // Used to track the direction of the player
        Left,
        Right
    }

    direction playerDirection = direction.Right;
    playerState state;
    public Animator animator;
    public Rigidbody2D rb;


    public void flipAnimation()
    {
        //Flips the character horizontally, called when the character is facing the wrong way
        transform.localScale = new Vector3(
          (transform.localScale.x * -1),
          transform.localScale.y,
          transform.localScale.z);
    }


    void animate()
    {
        //Sets the animator to play the appropriate annimation
        if (state == playerState.Idle)
        {
            animator.Play("PlayerIdle");
        }
        else if (state == playerState.WalkLeft)
        {
            animator.Play("PlayerWalk");
        }
        else if (state == playerState.WalkRight)
        {
            animator.Play("PlayerWalk");
        }
        else if (state == playerState.Jump)
        {
            animator.Play("PlayerJump");
        }
    }

    void getState()
    {
        //Works out what state the player is in (See playerState) and which direction they are facing
        if (rb.velocity.y != 0)
        {
            state = playerState.Jump;
            if (playerDirection == direction.Left && rb.velocity.x > 0) //midair direction changes
            {
                flipAnimation();
                playerDirection = direction.Right;
            }
            else if (playerDirection == direction.Right && rb.velocity.x <0)
            {
                flipAnimation();
                playerDirection = direction.Left;
            }
        }
        else if (rb.velocity.x > 0)
        {
            if (playerDirection == direction.Left)
            {
                flipAnimation();
            }
            state = playerState.WalkRight;
            playerDirection = direction.Right;
        }
        else if (rb.velocity.x < 0)
        {
            if (playerDirection == direction.Right)
            {
                flipAnimation();
            }
            state = playerState.WalkLeft;
            playerDirection = direction.Left;
        }
        else
        {
            state = playerState.Idle;
        }
    }

    void FixedUpdate()
    {
        //Calls the functions required to animate
        getState();
        animate();
    }
}
