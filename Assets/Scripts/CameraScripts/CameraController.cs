using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject self;
    public int peakDistance;
    Vector2 peakVector;
    bool peakBool;

    //Sets the location of the camera to follow the player
    void followPlayer()
    {
        self.transform.position = new Vector3(player.transform.position.x+peakVector.x, player.transform.position.y+ peakVector.y, self.transform.position.z);
    }

    //Use of the peak mechanic: Takes an input and pushes the camera slightly in that direction (As implemented above)
    public void peak(InputValue input)
    {
        peakVector = input.Get<Vector2>();
        peakVector = peakVector * peakDistance;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
}
