using UnityEngine; // Import Unity engine classes and functions


// Need to fix the circle path so it doesn't go out of bounds
public class Enemy : MonoBehaviour // Enemy class inherits from MonoBehaviour (Unity component base class)
{
    
    private float enemySpeed = 3f; // Speed at which enemy moves (units per second) - controls how fast the angle increases
    
    void Start() // Called once when the GameObject is first created/activated
    {
       
    }

    void Update() // Called every frame (typically 60 times per second)
    {
        // Call the current movement function
        EnemyMovement();
    }
    
    void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D)
    {
        // Die if hit by bullet
        if(other.gameObject.CompareTag("Bullet")) // Check if the colliding object has the "Bullet" tag
        {
            Destroy(other.gameObject); // Destroy the bullet GameObject that hit the enemy
            Destroy(gameObject); // Destroy this enemy GameObject
            Debug.Log("Enemy hit by bullet and died"); // Print message to console for debugging
        }
    }

    void EnemyMovement(){
        transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
        if(transform.position.x > 6 || transform.position.x < -6){
            enemySpeed = -enemySpeed;
        }
    }
   

}
