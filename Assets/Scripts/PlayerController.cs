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

    public Material shieldMaterial; // Reference to the shield material (assigned in Unity Inspector)
    public float shieldDuration = 3f; // Duration of the shield in seconds
    private bool isShieldActive = false; // Flag to track if shield is currently active
    private Material originalMaterial; // Store the original player material
    
    public AudioClip powerUpSound; // Reference to the power up sound (assigned in Unity Inspector)
    public AudioClip powerDownSound; // Reference to the power down sound (assigned in Unity Inspector)
    public AudioClip healthupSound; // Reference to the health up sound (assigned in Unity Inspector)
    public AudioClip shootSound; // Reference to the shoot sound (assigned in Unity Inspector)
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpeed = 6.0f; // Set the player's movement speed to 6 units per second
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get its GameManager component script
        originalMaterial = GetComponent<MeshRenderer>().material; // Store the original material
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
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
            PlayShootSound(); // Play the shoot sound
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), bulletPrefab.transform.rotation);
        }
    }
    public void LoseALife() // Method called when player is hit by an enemy
    {
        gameManager.LoseALife(); // Call the GameManager's LoseALife method to decrement lives and check for game over
        
    }
    public void AddALife() // Method called when player collects a health power up
    {   
        gameManager.AddALife(); // Call the GameManager's AddALife method to increment lives
        PlayPowerUpSound(); // Play the power up sound
    }

    public void ActivateShield() // Method called when player collects a shield power up
    {
        if(!isShieldActive) // Only activate if shield is not already active
        {
            isShieldActive = true; // Set shield flag to active
            GetComponent<Collider>().enabled = false; // Disable the player's collider
            
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if(meshRenderer != null && shieldMaterial != null) // Check if renderer exists and shield material is assigned
            {
                meshRenderer.material = shieldMaterial; // Change material to shield color
            }
            
            PlayPowerUpSound(); // Play the power up sound
            StartCoroutine(ShieldDuration()); // Start the shield duration coroutine
        }
    }
    
    void PlayPowerUpSound() // Method to play the power up sound
    {
        if(audioSource != null && powerUpSound != null) // Check if AudioSource exists and sound is assigned
        {
            audioSource.PlayOneShot(powerUpSound); // Play the power up sound
        }
    }

    void PlayShootSound() // Method to play the shoot sound
    {
        if(audioSource != null && shootSound != null) // Check if AudioSource exists and sound is assigned
        {
            audioSource.PlayOneShot(shootSound); // Play the shoot sound
        }
    }

    void PlayPowerDownSound() // Method to play the power down sound
    {
        if(audioSource != null && powerDownSound != null) // Check if AudioSource exists and sound is assigned
        {
            audioSource.PlayOneShot(powerDownSound); // Play the power down sound
        }
    }

    IEnumerator ShieldDuration() // Coroutine to handle shield duration
    {
        yield return new WaitForSeconds(shieldDuration); // Wait for the shield duration
        isShieldActive = false; // Set shield flag to inactive
        GetComponent<Collider>().enabled = true; // Enable the player's collider
        GetComponent<MeshRenderer>().material = originalMaterial; // Restore original material
        PlayPowerDownSound(); // Play the power down sound
    }
    
}
