using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    float timer;
    public GameObject heartSoundManager;
    AudioSource heartSFX;

    private void Start()
    {
        heartSFX = heartSoundManager.GetComponent<AudioSource>();
        heartSFX.volume = PlayerPrefs.GetFloat("SFXVol");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player collides with the pickup the player is healed and the pickup is destroyed
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthController>().heal(1);
            heartSFX.Play();
            Destroy(gameObject);
        }
    }

    void bob ()
    {
        //Simply makes the pickup bob up and down in space, serves no particular purpose other than looking nice
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
