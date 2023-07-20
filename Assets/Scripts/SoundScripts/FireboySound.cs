using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboySound : MonoBehaviour
{
    public AudioSource sound;

    void Start()
    {
        //Sets the volume to be equal to what the player set in the main menu
        sound.volume = PlayerPrefs.GetFloat("SFXVol");
    }
}
