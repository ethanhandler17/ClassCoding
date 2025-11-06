using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    //variables
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalUpperScreenLimit = 0.0f;
    private float verticalLowerScreenLimit = -3.5f;

    public GameObject bulletPrefab; // Reference to the bullet prefab to spawn (assigned in Unity Inspector)

    private GameManager gameManager; // Reference to the GameManager component - used to access game management functions like losing lives

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpeed = 6.0f; // Set the player's movement speed to 6 units per second
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get its GameManager component script
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();        
    }


    void Movement()
    {
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");
       //move the player
       transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
       //keep the player in bounds
       // if the player is out of bounds, moves them to the opposite side of the screen
       if(transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
       {
        transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
       }
       transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, verticalLowerScreenLimit, verticalUpperScreenLimit), 0);
       
    }
    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shooting");
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), bulletPrefab.transform.rotation);
        }
    }
    public void LoseALife() // Method called when player is hit by an enemy
    {
        if(gameManager != null) // Check if GameManager reference exists
        {
            gameManager.LoseALife(); // Call the GameManager's LoseALife method to decrement lives and check for game over
        }
        else // If GameManager reference is null
        {
            Debug.LogWarning("GameManager not found! Cannot lose a life."); // Print warning message to console
        }
    }





}
