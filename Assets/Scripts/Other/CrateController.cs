using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float raycastOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void airCheck()
    {
        //This function serves to check if the crate should be falling, if so it makes it fall straight down without moving sideways (There was no particular reason for this it just makes the crate falling feel better, somewhat inspired by how pushing blocks in Spelunky works)
        LayerMask platform = LayerMask.GetMask("Platform");

        Vector2 floorCheck1Vector = transform.position;
        floorCheck1Vector.x = transform.position.x - raycastOffset;
        Vector2 floorCheck2Vector = transform.position;
        floorCheck2Vector.x = transform.position.x + raycastOffset;
        RaycastHit2D floorCheck1 = Physics2D.Raycast(floorCheck2Vector, -transform.up, 0.75f, platform);
        RaycastHit2D floorCheck2 = Physics2D.Raycast(floorCheck1Vector, -transform.up, 0.75f, platform);

        Debug.DrawRay(floorCheck2Vector, -transform.up, Color.red, 1.0f);
        Debug.DrawRay(floorCheck1Vector, -transform.up, Color.red, 1.0f);

        if (!floorCheck1.collider && !floorCheck2.collider)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        airCheck();
    }
}
