using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject player;
    public GameObject self;

    public bool isMainmenu;

    AudioSource music;

    void Start()
    {
        //Sets the volume to the value determined by the player int he menu, saved as a playerpref
        music = self.GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("musicVol");
    }

    void followPlayer()
    {
        //Follows the player, much like the camera does
        self.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, self.transform.position.z);
    }



    // Update is called once per frame
    void Update()
    {
        if (isMainmenu)
        {
            //If the music is being played in the menu it needs to constantly be checking the player's set volume as it may be changing
            music.volume = PlayerPrefs.GetFloat("musicVol");
        }
    }
}
