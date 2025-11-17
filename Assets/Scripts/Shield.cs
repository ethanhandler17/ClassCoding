using UnityEngine;

public class Shield : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyPowerUp", 10f); // Schedule the DestroyPowerUp method to be called after 10 seconds
    }
    void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D) - handles collision detection
    {
        if(other.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            PlayerController playerController = other.GetComponent<PlayerController>(); // Get PlayerController component from colliding object
            if(playerController != null) // Check if PlayerController component exists
            {
                playerController.ActivateShield(); // Call ActivateShield method on PlayerController to activate the shield
            }
            Destroy(gameObject); // Destroy this shield power up GameObject
        }
    }
    
    void DestroyPowerUp() // Method to destroy the power up after 10 seconds
    {
        Destroy(gameObject); // Destroy this shield power up GameObject
    }
}
