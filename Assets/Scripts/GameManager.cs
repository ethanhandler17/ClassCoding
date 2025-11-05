using UnityEngine; // Import Unity engine classes and functions
using System; // Import System namespace for Action delegate type and other utilities

public class GameManager : MonoBehaviour // GameManager class inherits from MonoBehaviour (Unity component base class)
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn (assigned in Unity Inspector)
    public GameObject enemyPrefab2; // Reference to the second enemy prefab to spawn (assigned in Unity Inspector)
    
    void Start() // Called once when the GameObject is first created/activated
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f); // Start repeatedly calling SpawnEnemy method every 1 second, starting immediately (0f delay)
        InvokeRepeating("SpawnEnemy2", 0f, 3f); // Start repeatedly calling SpawnEnemy2 method every 1 second, starting immediately (0f delay)
    }
    
    void SpawnEnemy() // Function to spawn both enemy types at random positions
    {
        Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-6, 6), 3, 0), Quaternion.identity); // Create first enemy type at random X position (-6 to 6) and y position 3 with no rotation
        Instantiate(enemyPrefab2, new Vector3(UnityEngine.Random.Range(-6, 6), 3, 0), Quaternion.identity); // Create second enemy type at random X position (-6 to 6) and y position 3 with no rotation
    }
}
