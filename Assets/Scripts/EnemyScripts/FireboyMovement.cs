using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboyMovement : MonoBehaviour
{
    public bool right;
    public bool stuck = false;
    public int moveSpeed;
    public Rigidbody2D rb;
    public float raycastOffset;


    void Start()
    {
        right = false;
    }

    void movement()
    {
        sideCheck();

        //If the enemy is stuck this means it doesn't constantly flick around which is painful on the eyes
        if (stuck)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //If the enemy should be moving right it does
        else if (right)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        //Else it moves left
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

    }

    void sideCheck()
    {
        //This function uses raycasts to check if there is anything blocking it on either side - it does both a high check and a low check as if it checks in the middle it can still get stuck
        LayerMask platform = LayerMask.GetMask("Platform");
        LayerMask enemy = LayerMask.GetMask("Enemy");
        Vector2 temp = transform.position;
        temp.y += raycastOffset;
        Vector2 temp2 = transform.position;
        temp2.y -= raycastOffset;
        RaycastHit2D rightCheck1 = Physics2D.Raycast(temp, transform.right, 0.6f, platform);
        RaycastHit2D rightCheck2 = Physics2D.Raycast(temp2, transform.right, 0.6f, platform);
        RaycastHit2D leftCheck1 = Physics2D.Raycast(temp, -transform.right, 0.6f, platform);
        RaycastHit2D leftCheck2 = Physics2D.Raycast(temp2, -transform.right, 0.6f, platform);

        Debug.DrawRay(temp, -transform.right, Color.red, 1.0f);
        Debug.DrawRay(temp2, transform.right, Color.red, 1.0f);
        Debug.DrawRay(temp, -transform.right, Color.red, 1.0f);
        Debug.DrawRay(temp2, transform.right, Color.red, 1.0f);

        if ((rightCheck1.collider || rightCheck2.collider) && (leftCheck1.collider || leftCheck2.collider))
        {
            stuck = true;
        }
        else  if (rightCheck1.collider || rightCheck2.collider)
        {
            right = false;
            stuck = false;
            transform.localScale = new Vector3(
          (transform.localScale.x * -1),
          transform.localScale.y,
          transform.localScale.z);
        }
        else if (leftCheck1.collider || leftCheck2.collider)
        {
            right = true;
            stuck = false;
            transform.localScale = new Vector3(
          (transform.localScale.x * -1),
          transform.localScale.y,
          transform.localScale.z);
        }
    }

    


    void FixedUpdate()
    {
        movement();
    }
}
