using UnityEngine; // Import Unity engine classes and functions
using System; // Import System namespace for Action delegate type and other utilities
using UnityEngine.SceneManagement; // Import SceneManagement namespace for loading scenes
using System.Collections; // Import System.Collections namespace for IEnumerator type and other utilitie
using TMPro; // Import TextMeshPro namespace for UI text components

public class GameManager : MonoBehaviour // GameManager class inherits from MonoBehaviour (Unity component base class)
{ // Opening brace for GameManager class
    public GameObject player; // Reference to the player prefab to spawn (assigned in Unity Inspector)
    private GameObject playerInstance; // Reference to the instantiated player GameObject in the scene
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn (assigned in Unity Inspector)
    public GameObject enemyPrefab2; // Reference to the second enemy prefab to spawn (assigned in Unity Inspector)
    public GameObject cloudPrefab; // Reference to the cloud prefab to spawn (assigned in Unity Inspector)
    public float verticalScreenSize = 6.0f; // for clouds, the bottom of the screen is -5
    public float horizontalScreenSize = 6.0f; // for clouds, the right of the screen is 6
    public GameObject audioSouce; // Reference to the audio source game object (assigned in Unity Inspector)
    public AudioClip powerUpSound; // Reference to the power up sound (assigned in Unity Inspector)
    public AudioClip powerDownSound; // Reference to the power down sound (assigned in Unity Inspector)
    public GameObject HealthUpPowerUpPrefab; // Reference to the health up health power up prefab to spawn (assigned in Unity Inspector)

    public GameObject coinPrefab; // Reference to the coin prefab to spawn (assigned in Unity Inspector)

    public int score = 0; // Player's current score
    public int lives = 3; // Number of lives the player has remaining (starts at 3)
    
    public GameObject heart1; // Reference to the first heart image GameObject (assigned in Unity Inspector)
    public GameObject heart2; // Reference to the second heart image GameObject (assigned in Unity Inspector)
    public GameObject heart3; // Reference to the third heart image GameObject (assigned in Unity Inspector)
     public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component that displays the score (assigned in Unity Inspector)

    void Start() // Called once when the GameObject is first created/activated
    { // Opening brace for Start method
        InvokeRepeating("SpawnEnemy", 0f, 1f); // Start repeatedly calling SpawnEnemy method every 1 second, starting immediately (0f delay)
        InvokeRepeating("SpawnEnemy2", 5f, 5f); // Start repeatedly calling SpawnEnemy2 method every 5 second, starting immediately (10f delay)
        InvokeRepeating("SpawnCloud", 0f, 5f); // Start repeatedly calling SpawnCloud method every 5 second, starting immediately (0f delay)
        playerInstance = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity); // Spawn the player at the center of the screen and store the reference


        score = 0; // Initialize score to 0
        lives = 3; // Initialize lives to 3
        UpdateHearts(); // Update the heart display to show all hearts initially
        StartCoroutine(SpawnPowerUp()); // Start the coroutine to spawn power ups
    } // Closing brace for Start method
    
    void SpawnEnemy() // Function to spawn first enemy type at random positions
    { // Opening brace for SpawnEnemy method
        Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(0, 9), 0), Quaternion.identity); // Create first enemy type at random X position (-6 to 6) and UnityEngine.Random.Range(0, 6) with no rotation
    } // Closing brace for SpawnEnemy method
    
    void SpawnEnemy2() // Function to spawn second enemy type at random positions
    { // Opening brace for SpawnEnemy2 method
        Instantiate(enemyPrefab2, new Vector3(UnityEngine.Random.Range(-6, 6), UnityEngine.Random.Range(0, -3), 0), Quaternion.identity); // Create second enemy type at random X position (-6 to 6) and UnityEngine.Random.Range(0, 6) with no rotation
    } // Closing brace for SpawnEnemy2 method

    public void AddScore(int pointsToAdd) // Method to add points to the player's score
    { // Opening brace for AddScore method
        score += pointsToAdd; // Add the specified points to the current score
        UpdateScoreText(); // Update the score text to display the current score
    } // Closing brace for AddScore method
    void UpdateScoreText() // Method to update the score text to display the current score
    { 
        if(scoreText != null) // Check if scoreText reference exists
        { 
            scoreText.text = "Score: " + score.ToString(); // Update the text to display the current score
        } 
    } 
    public void LoseALife() // Method to handle player losing a life
    { // Opening brace for LoseALife method
        lives--; // Decrement the number of lives by 1
        Debug.Log("Lives remaining: " + lives); // Print the remaining lives to the console
        UpdateHearts(); // Update the heart display to reflect the new number of lives

        
        if(lives <= 0) // Check if player has no lives remaining
        { // Opening brace for if statement
            GameOver(); // Call the game over method
        } // Closing brace for if statement
    } // Closing brace for LoseALife method

    public void AddALife() // Method to add a life to the player
    { // Opening brace for AddALife method
        if(lives < 3) // Check if player has less than 3 lives  
        { // Opening brace for if statement
            lives++; // Increment the number of lives by 1
            Debug.Log("Lives remaining: " + lives); // Print the remaining lives to the console
            UpdateHearts(); // Update the heart display to reflect the new number of lives
        } // Closing brace for if statement
    } 
    void UpdateHearts() // Method to update the heart display based on remaining lives
    { // Opening brace for UpdateHearts method
        if(heart1 != null) // Check if heart1 reference exists
        { // Opening brace for first if statement
            heart1.SetActive(lives >= 1); // Show heart1 if lives is 1 or more
        } // Closing brace for first if statement
        if(heart2 != null) // Check if heart2 reference exists
        { // Opening brace for second if statement
            heart2.SetActive(lives >= 2); // Show heart2 if lives is 2 or more
        } // Closing brace for second if statement
        if(heart3 != null) // Check if heart3 reference exists
        { // Opening brace for third if statement
            heart3.SetActive(lives >= 3); // Show heart3 if lives is 3 or more
        } // Closing brace for third if statement
    } // Closing brace for UpdateHearts method

    void GameOver() // Method to handle game over state
    { // Opening brace for GameOver method
        Debug.Log("Game Over! Final Score: " + score); // Print game over message with final score
        PlayerPrefs.SetInt("FinalScore", score); // Save the final score to PlayerPrefs so it can be accessed in the GameOver scene
        PlayerPrefs.Save(); // Save PlayerPrefs to disk
        // Open the game over scene
        SceneManager.LoadScene("GameOver"); // Load the GameOver scene
    } // Closing brace for GameOver method

    void SpawnCloud() // Function to spawn cloud at random positions at the top of the screen
    { // Opening brace for SpawnCloud method
        Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-6, 6), verticalScreenSize, 0), Quaternion.identity); // Create cloud at random X position (-6 to 6) and verticalScreenSize with no rotation

                
    } // Closing brace for SpawnCloud method

    IEnumerator SpawnPowerUp(){ // Coroutine method that returns IEnumerator to spawn power ups at random intervals
        float spawnTime = UnityEngine.Random.Range(3,5); // Generate a random wait time between 3 and 5 seconds
        yield return new WaitForSeconds(spawnTime); // Wait for the randomly generated time before continuing
        CreatePowerUp(); // Call CreatePowerUp method to instantiate a power up
        StartCoroutine(SpawnPowerUp()); // Recursively call this coroutine to spawn the next power up after another random delay
    } // Closing brace for SpawnPowerUp coroutine

    void CreatePowerUp(){ // Method to instantiate a power up at a random position
        Instantiate(HealthUpPowerUpPrefab, new Vector3(UnityEngine.Random.Range(-6f, 6f), UnityEngine.Random.Range(-4f, -3f), 0), Quaternion.identity); // Create health up power up at random X position (-6 to 6) and random Y position (-4 to -3) with no rotation
        //Destroy the power up after 10 seconds
        Instantiate(coinPrefab, new Vector3(UnityEngine.Random.Range(-6f, 6f), UnityEngine.Random.Range(-4f, -3f), 0), Quaternion.identity); // Create coin at random X position (-6 to 6) and random Y position (-4 to -3) with no rotation
        
    } // Closing brace for CreatePowerUp method
    

} 
