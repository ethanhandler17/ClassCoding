using UnityEngine; // Import Unity engine classes and functions
using System; // Import System namespace for Action delegate type and other utilities
using UnityEngine.SceneManagement; // Import SceneManagement namespace for loading scenes

public class GameManager : MonoBehaviour // GameManager class inherits from MonoBehaviour (Unity component base class)
{
    public GameObject player; // Reference to the player prefab to spawn (assigned in Unity Inspector)
    private GameObject playerInstance; // Reference to the instantiated player GameObject in the scene
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn (assigned in Unity Inspector)
    public GameObject enemyPrefab2; // Reference to the second enemy prefab to spawn (assigned in Unity Inspector)
    public GameObject cloudPrefab; // Reference to the cloud prefab to spawn (assigned in Unity Inspector)
    public float verticalScreenSize = 6.0f; // for clouds, the bottom of the screen is -5
    public float horizontalScreenSize = 6.0f; // for clouds, the right of the screen is 6

    public int score = 0; // Player's current score
    public int lives = 3; // Number of lives the player has remaining (starts at 3)
    
    public GameObject heart1; // Reference to the first heart image GameObject (assigned in Unity Inspector)
    public GameObject heart2; // Reference to the second heart image GameObject (assigned in Unity Inspector)
    public GameObject heart3; // Reference to the third heart image GameObject (assigned in Unity Inspector)

    void Start() // Called once when the GameObject is first created/activated
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f); // Start repeatedly calling SpawnEnemy method every 1 second, starting immediately (0f delay)
        InvokeRepeating("SpawnEnemy2", 5f, 5f); // Start repeatedly calling SpawnEnemy2 method every 5 second, starting immediately (10f delay)
        InvokeRepeating("SpawnCloud", 0f, 5f); // Start repeatedly calling SpawnCloud method every 5 second, starting immediately (0f delay)
        playerInstance = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity); // Spawn the player at the center of the screen and store the reference
        score = 0; // Initialize score to 0
        lives = 3; // Initialize lives to 3
        UpdateHearts(); // Update the heart display to show all hearts initially
    }
    
    void SpawnEnemy() // Function to spawn first enemy type at random positions
    {
        Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(0, 9), 0), Quaternion.identity); // Create first enemy type at random X position (-6 to 6) and UnityEngine.Random.Range(0, 6) with no rotation
    }
    
    void SpawnEnemy2() // Function to spawn second enemy type at random positions
    {
        Instantiate(enemyPrefab2, new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(0, -3), 0), Quaternion.identity); // Create second enemy type at random X position (-6 to 6) and UnityEngine.Random.Range(0, 6) with no rotation
    }

    public void AddScore(int pointsToAdd) // Method to add points to the player's score
    {
        score += pointsToAdd; // Add the specified points to the current score
        Debug.Log("Score: " + score); // Print the updated score to the console
    }

    public void LoseALife() // Method to handle player losing a life
    {
        lives--; // Decrement the number of lives by 1
        Debug.Log("Lives remaining: " + lives); // Print the remaining lives to the console
        UpdateHearts(); // Update the heart display to reflect the new number of lives
        
        if(lives <= 0) // Check if player has no lives remaining
        {
            GameOver(); // Call the game over method
        }
    }

    void UpdateHearts() // Method to update the heart display based on remaining lives
    {
        if(heart1 != null) // Check if heart1 reference exists
        {
            heart1.SetActive(lives >= 1); // Show heart1 if lives is 1 or more
        }
        if(heart2 != null) // Check if heart2 reference exists
        {
            heart2.SetActive(lives >= 2); // Show heart2 if lives is 2 or more
        }
        if(heart3 != null) // Check if heart3 reference exists
        {
            heart3.SetActive(lives >= 3); // Show heart3 if lives is 3 or more
        }
    }

    void GameOver() // Method to handle game over state
    {
        Debug.Log("Game Over! Final Score: " + score); // Print game over message with final score
        PlayerPrefs.SetInt("FinalScore", score); // Save the final score to PlayerPrefs so it can be accessed in the GameOver scene
        PlayerPrefs.Save(); // Save PlayerPrefs to disk
        // Open the game over scene
        SceneManager.LoadScene("GameOver"); // Load the GameOver scene
    }

    void SpawnCloud()
    {
        Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-6, 6), verticalScreenSize, 0), Quaternion.identity); // Create cloud at random X position (-6 to 6) and UnityEngine.Random.Range(0, 9) with no rotation
        
    }

    
}
