using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    float timer;
    public GameObject scorer;


    void levelEnd()
    {
        //Gets the total score to give the player in the next menu, then loads it
        scorer.GetComponent<ScoreManager>().setTotalScore();
        SceneManager.LoadScene("LevelComplete");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Calls the function to end the level if the player collides with the item
        if (collision.gameObject.tag == "Player")
        {
            levelEnd();
        }
    }
}

