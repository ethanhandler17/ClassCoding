using UnityEngine; // Import Unity engine classes and functions


// Need to fix the square path so it doesn't go out of bounds
public class Enemy2 : MonoBehaviour // Enemy class inherits from MonoBehaviour (Unity component base class)
{
    
    private float enemySpeed = 3f; // Speed at which enemy moves (units per second)
    private float squareSideLength = 2f; // Length of each side of the square path (in units)
    private int squareSide = 0; // Current side of square being traversed (0=right, 1=up, 2=left, 3=down)
    private float distanceTraveled = 0f; // Distance traveled along current side of square (in units)
    private Vector3 squareStartPos; // Starting position of the square path
     public GameObject explosionPrefab; // Reference to the explosion prefab GameObject (assigned in Unity Inspector) - used to spawn explosion effect when enemy dies
    private GameManager gameManager; // Reference to the GameManager component - used to access game management functions like adding score
    void Start() // Called once when the GameObject is first created/activated
    {
        squareStartPos = transform.position; // Store initial position as square starting point
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get its GameManager component script
    }

    void Update() // Called every frame (typically 60 times per second)
    {
        // Call the current movement function
        EnemyMovementSquare(); // Execute square movement pattern every frame
    }
    
    void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D) - handles collision detection
    {
        // Die if hit by bullet
        if(other.gameObject.CompareTag("Bullet")) // Check if the colliding object has the "Bullet" tag
        {
            Destroy(other.gameObject); // Destroy the bullet GameObject that hit the enemy
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); // Create an explosion effect at the enemy's current position and rotation
            Destroy(explosion, 0.3f); // Destroy the explosion GameObject after 0.3 seconds (allows animation to play)
            gameManager.AddScore(10); // Add 10 points to the player's score via the GameManager
            Destroy(gameObject); // Destroy this enemy GameObject
            Debug.Log("Enemy hit by bullet and died"); // Print message to console for debugging purposes
        }
        // Die if hit by bullet
        else if(other.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            other.GetComponent<PlayerController>().LoseALife(); // Get Player component from colliding object and call LoseALife method
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); // Create an explosion effect at the enemy's current position and rotation
            Destroy(explosion, 0.3f); // Destroy the explosion GameObject after 0.3 seconds (allows animation to play)
            Destroy(gameObject); // Destroy this enemy GameObject
            Debug.Log("Enemy hit by player and died"); // Print message to console for debugging purposes
        }
    }
    
    void EnemyMovementSquare() // Function to move enemy in a square path pattern
    {
        float moveDistance = enemySpeed * Time.deltaTime; // Calculate distance to move this frame (framerate-independent)
        distanceTraveled += moveDistance; // Add this frame's movement to total distance traveled on current side
        
        // Move in current direction using transform.Translate
        if (squareSide == 0) transform.Translate(moveDistance, 0, 0); // Move right along X axis
        else if (squareSide == 1) transform.Translate(0, moveDistance, 0); // Move up along Y axis
        else if (squareSide == 2) transform.Translate(-moveDistance, 0, 0); // Move left along negative X axis
        else transform.Translate(0, -moveDistance, 0); // Move down along negative Y axis
        
        // Switch to next side when we've traveled far enough
        if (distanceTraveled >= squareSideLength) // Check if we've completed current side of square
        {
            distanceTraveled = 0f; // Reset distance counter for next side
            squareSide = (squareSide + 1) % 4; // Cycle through 0,1,2,3 (modulo keeps it in range)
        }
    }

}
