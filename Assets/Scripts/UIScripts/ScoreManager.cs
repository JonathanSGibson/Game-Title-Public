using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int itemScore;
    int totalScore;
    public GameObject timer;

    void Start()
    {
        //Resets players score when level starts
        PlayerPrefs.SetInt("score", 0);
    }

    public int getScore()
    {
        //Returns the score, used for displaying it in the UI
        totalScore = itemScore;
        return totalScore;
    }

    public void addItemScore(int addition)
    {
        //Adds an amount to the item score (Called by coin pickups)
        itemScore += addition;
    }

    public void setTotalScore()
    {
        //Fetches and sets the total score, uses a playerpref to easily be used between scenes (This is called at the end of a level before loading the level complete menu)
        totalScore = itemScore + timer.GetComponent<TimeManager>().getTimeLeft();
        PlayerPrefs.SetInt("score",totalScore);
    }

    void FixedUpdate()
    {

    }
}
