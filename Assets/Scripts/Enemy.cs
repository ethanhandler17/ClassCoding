using UnityEngine; // Import Unity engine classes and functions


// Need to fix the circle path so it doesn't go out of bounds
public class Enemy : MonoBehaviour // Enemy class inherits from MonoBehaviour (Unity component base class)
{
    
    private float enemySpeed = 3f; // Speed at which enemy moves horizontally (units per second) - controls how fast the enemy moves left/right

    public GameObject explosionPrefab; // Reference to the explosion prefab GameObject (assigned in Unity Inspector) - used to spawn explosion effect when enemy dies
    private GameManager gameManager; // Reference to the GameManager component - used to access game management functions like adding score

    void Start() // Called once when the GameObject is first created/activated
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get its GameManager component script
    }

    void Update() // Called every frame (typically 60 times per second)
    {
        // Call the current movement function
        EnemyMovement(); // Execute the enemy movement logic every frame
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

    void EnemyMovement() // Function to handle enemy movement behavior
    {
        transform.Translate(enemySpeed * Time.deltaTime, 0, 0); // Move the enemy horizontally (X-axis) at enemySpeed units per second, multiplied by Time.deltaTime for frame-rate independent movement
        if(transform.position.y > 6 || transform.position.y < -6) // Check if enemy's Y position is above 6 or below -6 (screen boundaries)
        {
            enemySpeed = -enemySpeed; // Reverse the direction of movement by negating the speed value (bounces enemy off screen edges)
        }
    }
   
   /*private void OnTriggerEnter2D(Collider2D whatDidIHit) // Commented out: 2D collision detection method (not currently used)
   {
    if(whatDidIHit.gameObject.CompareTag("Player")) // Check if colliding object has "Player" tag
    {
        whatDidIHit.GetComponent<Player>().LoseALife(); // Get Player component from colliding object and call LoseALife method
        Instantiate(explosionPrefab, transform.position, transform.rotation); // Spawn explosion at enemy position
        Destroy(gameObject); // Destroy this enemy GameObject
    }
    else if(whatDidIHit.gameObject.CompareTag("Bullet")) // Check if colliding object has "Bullet" tag
    {
        Destroy(whatDidIHit.gameObject); // Destroy the bullet that hit the enemy
        Instantiate(explosionPrefab, transform.position, transform.rotation); // Spawn explosion at enemy position
        gameManager.AddScore(5); // Add 5 points to score
        Destroy(gameObject); // Destroy this enemy GameObject
    }
   } 
   */
}
