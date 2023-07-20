using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject scorer;

    void Update()
    {
        //Updates the on screen text with the current score
        text.SetText("Score\n" + scorer.GetComponent<ScoreManager>().getScore());
    }
}
