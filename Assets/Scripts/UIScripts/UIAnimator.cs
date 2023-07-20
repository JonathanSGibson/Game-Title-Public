using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    //This script is simply to allow me to animate a UI image
    //It uses the animator to flick through sprites, then takes the sprite currently being rendered and applies that to the image

    SpriteRenderer sprite;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprite.sprite;
    }
}
