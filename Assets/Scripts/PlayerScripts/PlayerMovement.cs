using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject self;
    public GameObject mainCamera;
    public Rigidbody2D rb;
    public int moveSpeed;
    public int jumpForce;
    float horizontalVelocity;
    bool doubleJump;
    public float killY;

    public float raycastOffset;

    public AudioSource jumpSFX;

    enum jumpState
    {
        falling,
        grounded,
    }

    jumpState currentJumpState;

    private void Start()
    {
        jumpSFX.volume = PlayerPrefs.GetFloat("SFXVol");
        if (jumpSFX.volume <= 0.75)
        {
            jumpSFX.volume = jumpSFX.volume * 1.5f;
        }
    }

    void movementController()
    {
        //Sets the player's velocity according to what is set by their inputs
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    public void OnMove(InputValue input)
    {
        //Sets the player's horizontal velocity - Changing the velocity directly rather than adding a force allows for much snappier movement where you can control exactly when you stop and start, which in my opinion is best for a platformer
        Vector2 movementValue = input.Get<Vector2>();
        horizontalVelocity = movementValue.x * moveSpeed;
    }

    public void OnJump()
    {
        //Checks if the player is able to jump, if so it adds an upwards force
        if (currentJumpState == jumpState.grounded)
        {
            Vector2 jumpVector = new Vector2(0, jumpForce);
            rb.AddForce(jumpVector, ForceMode2D.Impulse);
            currentJumpState = jumpState.falling;
            jumpSFX.Play();
        }
        else if(currentJumpState == jumpState.falling && doubleJump == true)
        {
            Vector2 jumpVector = new Vector2(0, jumpForce);
            rb.AddForce(jumpVector, ForceMode2D.Impulse);
            doubleJump = false;
            jumpSFX.Play();
        }
    }

    void jumpTest()
    {
        //Uses raycasts to check if the player is in a position to jump or not
        if (rb.velocity.y <= 0.0f && currentJumpState != jumpState.grounded)
        {
            LayerMask platform = LayerMask.GetMask("Platform");

            Vector2 floorCheck1Vector = transform.position;
            floorCheck1Vector.x = transform.position.x - raycastOffset;
            Vector2 floorCheck2Vector = transform.position;
            floorCheck2Vector.x = transform.position.x + raycastOffset;
            RaycastHit2D floorCheck1 = Physics2D.Raycast(floorCheck2Vector, -transform.up, 0.75f, platform);
            RaycastHit2D floorCheck2 = Physics2D.Raycast(floorCheck1Vector, -transform.up, 0.75f, platform);

            Debug.DrawRay(floorCheck2Vector, -transform.up, Color.red, 1.0f);
            Debug.DrawRay(floorCheck1Vector, -transform.up, Color.red, 1.0f);

            if (floorCheck1.collider || floorCheck2.collider)
            {
                currentJumpState = jumpState.grounded;
                doubleJump = true;
            }
            else
            {
                currentJumpState = jumpState.falling;
            }
        }

    }

    public void OnPeak(InputValue input)
    {
        //Set the camera to go to one side of the player
        mainCamera.GetComponent<CameraController>().peak(input);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if the player is low enough in the level that it should kill them, if so loads the "game over" menu. Otherwise calls the other functions required to control movement
        if (transform.position.y < killY)
        {
            SceneManager.LoadScene("GameOver");
        }
        movementController();
        jumpTest();
    }
}
