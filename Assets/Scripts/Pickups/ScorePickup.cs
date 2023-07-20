using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public GameObject scoreManager;
    public int score;
    float timer;
    public GameObject coinAudio;
    AudioSource coinSFX;

    private void Start()
    {
        coinSFX = coinAudio.GetComponent<AudioSource>();
        coinSFX.volume = PlayerPrefs.GetFloat("SFXVol");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player collides with the pickup the score is added to and the pickup is destroyed
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.GetComponent<ScoreManager>().addItemScore(score);
            coinSFX.Play();
            Destroy(gameObject);
        }
    }
    void bob()
    {
        //Makes the pickup bob up and down in the air, serves no real purpose other than looking nice
        if (timer < 10)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.001f);
        }
        else if (timer >= 20)
        {
            timer = 0;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.001f);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 0.1f;
        bob();
    }
}
