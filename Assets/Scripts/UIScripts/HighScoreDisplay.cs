using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class HighScoreDisplay : MonoBehaviour
{

    [Serializable]
    public class HighScores
    {
        public List<string> playerNames;
        public List<int> playerScores;
    }

    string highScores;
    void Start()
    {
        getHighScores();
    }



    void getHighScores()
    {
        int displayCount = 1;
        //Used this as a reference for saving files: https://answers.unity.com/questions/1300019/how-do-you-save-write-and-load-from-a-file.html

        //First determine the destination of the save data, and create the object it will be loaded into if it already exists
        var destination = Path.Combine(Application.persistentDataPath, "/save.json");
        HighScores currentScores;
        string encodedScores;

        if (File.Exists(destination))
        {
            //Get the file and read the text from it, then convert that from Json to HighScores
            encodedScores = File.ReadAllText(destination);
            currentScores = JsonUtility.FromJson<HighScores>(encodedScores);

            while (currentScores.playerScores.Count > 0)
            {
                int temp = 0;
                int index = 0;
                //This for loop is designed to find the index of the highest score, the while loop repeats this until every score has been found
                for (int i = 0; i < currentScores.playerScores.Count; i++)
                {
                    if (currentScores.playerScores[i] > temp)
                    {
                        temp = currentScores.playerScores[i];
                        index = i;
                    }
                }
                //We then save each score to a string, which will then be displayed in text form
                highScores = highScores + displayCount + " - " + currentScores.playerNames[index]+ "\n" + currentScores.playerScores[index] + "\n\n";
                displayCount++;

                //and remove that score from the list
                currentScores.playerNames.RemoveAt(index);
                currentScores.playerScores.RemoveAt(index);
            }
        }
        else
        {
            //If no such file exists we display an appropriate alternative message
            highScores = "No high scores entered";
        }

        //Finally we make the high score actually display
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = highScores;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
