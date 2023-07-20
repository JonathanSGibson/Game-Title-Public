using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class ScoreSaver : MonoBehaviour
{
    public TextMeshProUGUI text;
    string playerName;
    int score;
    public GameObject toHide;
    public GameObject toShow;

    [Serializable]
    public class HighScores
    {
        public List<string> playerNames;
        public List<int> playerScores;
    }

    void Awake()
    {
        setScoreText();
    }

    public void save()
    {
        //Used this as a reference for saving files: https://answers.unity.com/questions/1300019/how-do-you-save-write-and-load-from-a-file.html

        //First determine the destination of the save data, and create the object it will be loaded into if it already exists
        var destination = Path.Combine(Application.persistentDataPath, "/save.json");
        HighScores currentScores;
        Debug.Log(destination);
        string encodedScores;


        if (File.Exists(destination))
        {
            //If the file exists then you grab that for the scores
            encodedScores = File.ReadAllText(destination);
            currentScores = JsonUtility.FromJson<HighScores>(encodedScores);
        }
        else
        {
            //Else we create the save data
            currentScores = new HighScores();
            currentScores.playerNames = new List<string>();
            currentScores.playerScores = new List<int>();
        }

        //Add to both the list of names and scores
        currentScores.playerNames.Add(playerName);
        currentScores.playerScores.Add(score);

        //Then put them back into the Json format, and save it
        encodedScores = JsonUtility.ToJson(currentScores);
        File.WriteAllText(destination, encodedScores);
        


        //Activates and deactivates appropriate game objects to effectively go back in the menu after saving the score
        toHide.SetActive(false);
        toShow.SetActive(true);
    }

    public void setScoreText()
    {
        //Displays the score
        score = PlayerPrefs.GetInt("score");
        text.SetText("Score\n" + score);
    }

    public void setName(string newName)
    {
        //Sets the players input as the name to be saved with the score
        playerName = newName;
        Debug.Log(playerName);
    }
}
