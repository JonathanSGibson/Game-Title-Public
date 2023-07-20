using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject toHide;
    public GameObject toShow;

    //As the script I use for all my menu buttons it needs to  be able to change which "page" of the menu it's on (Done by ShowCanvas()), load a different scene (Done via LoadScene()) and quit the application (Done via Quit())

    public void LoadScene()
    {
        //Loads a scene set in the inspector
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowCanvas()
    {
        //Activates and deactivates objects set in the inspector to change the page of the menu
        toHide.SetActive(false);
        toShow.SetActive(true);
    }

    public void Quit()
    {
        //Closes the game
        Application.Quit();
    }
}
