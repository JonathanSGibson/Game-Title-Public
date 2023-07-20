using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public GameObject[] hearts = new GameObject[5];
    public AudioSource damageSFX;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the player to start on max hp at the start of the level
        currentHP = maxHP;
        damageSFX.volume = PlayerPrefs.GetFloat("SFXVol");
    }

    public void takeDamage(int damage)
    {
        damageSFX.Play();
        //Function which controls the taking of damage, first it alters the currentHP variable by the amount of damage taken
        currentHP -= damage;
        //Then if the player is dead it loads the game over screen
        if (currentHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        //Otherwise it sets the correct number of hearts to be actrive
        else
        {
            Debug.Log("test");

            for (int i = maxHP - 1; i >= currentHP; i--)
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void heal(int healing)
    {
        //Works the same as the takeDamage function but with adding to HP rather than subtracting, though cannot go above max HP
        currentHP += healing;
        if (currentHP > maxHP)
            currentHP = maxHP;


        for (int i = 0; i < currentHP; i++)
        {
            hearts[i].SetActive(true);
        }
    }
}
