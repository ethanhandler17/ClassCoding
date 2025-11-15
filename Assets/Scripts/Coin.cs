using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager component - used to access game management functions like adding score
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get its GameManager component script
        Invoke("DestroyCoin", 10f); // Schedule the DestroyCoin method to be called after 10 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D) - handles collision detection
    {
        if(other.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            if(gameManager != null) // Check if GameManager reference exists
            {
                gameManager.AddScore(10); // Call AddScore method on the GameManager to add 10 points to the score
            }
            Destroy(gameObject); // Destroy this coin GameObject
        }
    }
    void DestroyCoin() // Method to destroy the coin after 10 seconds
    {
        Destroy(gameObject); // Destroy this coin GameObject
    }
}
