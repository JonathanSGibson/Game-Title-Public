using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    int counter;
    int minutes;
    int seconds;
    int timeLeft;
    public int maxSeconds;

    // Start is called before the first frame update
    void Start()
    {
        //Sets how long the player has based on what has been input in the inspector, and sets up the time counter
        timeLeft = maxSeconds;
        counter = (int)Time.time;
    }

    void getTime()
    {
        //Controls the timer and identifies how long the player has remaining in the level
        if (Time.time >= counter)
        {
            counter++;
            timeLeft--;
            seconds = timeLeft;
            minutes = 0;
            while (seconds - 60 >= 0)
            {
                seconds -= 60;
                minutes++;
            }
        }

        //Sends player to the "game over" screen if they run out of time
        if(timeLeft <=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public int getTimeLeft()
    {
        //Public function to get the time, this function is used when working out the player's score in the level
        return timeLeft;
    }

    void setText()
    {
        //Sets the UI text to display the current time the player has left
        text.SetText("Time\n" + minutes + " - " + seconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getTime();
        setText();
    }
}
