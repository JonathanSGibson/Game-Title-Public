using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundSliders : MonoBehaviour
{

    public bool isMusic;

    public Slider volumeSlider;

    float currentMusicVol;
    float currentSFXVol;
    float lastValue;


    void Start()
    {
        int temp = PlayerPrefs.GetInt("firstPlay");
        if (temp == 0) //This if statement is not strictly necessary, however it means that it should default to max volume rather than min volume
        {
            //If this is the player's first time opening the menu automatically sets audio values to maximum and the sliders to match
            currentMusicVol = 1;
            PlayerPrefs.SetFloat("musicVol", currentMusicVol);
            currentSFXVol = 1;
            PlayerPrefs.SetFloat("SFXVol", currentSFXVol);
            volumeSlider.value = 1;
            PlayerPrefs.SetInt("firstPlay", 1);
            lastValue = 1;
        }
        else
        {
            //If the player has been through the menu before it fetches their previous audio settings from playerprefs and sets the sliders appropriately
            currentMusicVol = PlayerPrefs.GetFloat("musicVol");
            currentSFXVol = PlayerPrefs.GetFloat("SFXVol");
            if (isMusic)
            {
                lastValue = currentMusicVol;
                volumeSlider.value = currentMusicVol;
            }
            else
            {
                lastValue = currentSFXVol;
                volumeSlider.value = currentSFXVol;
            }
        }
    }



    void Update()
    {
        //Identifies if the player has changed the value of the slider and if so changes the approprait playerpref to match
        if (isMusic && lastValue != volumeSlider.value)
        {
            PlayerPrefs.SetFloat("musicVol", volumeSlider.value);
            Debug.Log(PlayerPrefs.GetFloat("musicVol"));
            lastValue = volumeSlider.value;
        }
        else if (lastValue != volumeSlider.value)
        {
            PlayerPrefs.SetFloat("SFXVol", volumeSlider.value);
            Debug.Log(PlayerPrefs.GetFloat("SFXVol"));
            lastValue = volumeSlider.value;
        }
    }
}
