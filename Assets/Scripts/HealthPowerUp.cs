using UnityEngine; // Import Unity engine classes and functions

public class HealthPowerUp : MonoBehaviour // HealthPowerUp class inherits from MonoBehaviour (Unity component base class)
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // Called once when the GameObject is first created/activated
    {
        Invoke("DestroyPowerUp", 10f); // Schedule the DestroyPowerUp method to be called after 10 seconds
    }

    // Update is called once per frame
    void Update() // Called every frame (typically 60 times per second)
    {
        // Empty Update method - no frame-by-frame logic needed
    }
    
    void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D) - handles collision detection
    {
        if(other.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); // Get PlayerController component from colliding object
            if(playerController != null) // Check if PlayerController component exists
            {
                playerController.AddALife(); // Call AddALife method on the player to increase lives
            }
            Destroy(gameObject); // Destroy this health power up GameObject
        }
    }
    
    void DestroyPowerUp() // Method to destroy the power up after 10 seconds
    {
        Destroy(gameObject); // Destroy this health power up GameObject
    }
}
