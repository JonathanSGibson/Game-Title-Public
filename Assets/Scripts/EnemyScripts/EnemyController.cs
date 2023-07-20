using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with the enemy it takes damage, which is handled by the health controller
        if (collision.gameObject.tag == "Player")
        {
            //whatever happens to handle damage
            Debug.Log("Damage");
            collision.gameObject.GetComponent<HealthController>().takeDamage(1);
        }
    }
}
